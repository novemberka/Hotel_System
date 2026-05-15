using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Hotel_System.Services
{
    public class InvoiceService
    {
        string connectionString =
            "server=localhost;database=hoteldb;uid=root;pwd=;";

        public DataTable GetInvoiceData(int bookingID)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con =
                new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = @"
                    SELECT 
                        b.BookingID,
                        c.FullName,
                        c.Phone,
                        r.RoomNumber,
                        rt.TypeName AS RoomType,
                        b.CheckInDate,
                        b.CheckOutDate,

                        DATEDIFF(b.CheckOutDate, b.CheckInDate) AS Days,

                        rt.PricePerNight AS Price,

                        (DATEDIFF(b.CheckOutDate, b.CheckInDate) 
                        * rt.PricePerNight) AS Total,

                        IFNULL(p.PaymentMethod, 'Not Paid') AS PaymentBy,

                        IFNULL(b.Status, 'Pending') AS Status

                    FROM bookings b
                    LEFT JOIN customers c 
                        ON b.CustomerID = c.CustomerID
                    LEFT JOIN rooms r 
                        ON b.RoomID = r.RoomID
                    LEFT JOIN roomtypes rt 
                        ON r.RoomTypeID = rt.RoomTypeID
                    LEFT JOIN payments p 
                        ON b.BookingID = p.BookingID

                    WHERE b.BookingID = @BookingID";

                    MySqlCommand cmd =
                        new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue(
                        "@BookingID",
                        bookingID
                    );

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(
                        "DB Error: " + ex.Message
                    );
                }
            }

            return dt;
        }
    }
}