using Hotel_System.Models;
using Hotel_System.Properties.Config;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Hotel_System.Repositories
{
    internal class BookingRepository
    {
        private readonly DbConnection db = new DbConnection();

        public DataTable GetBookingList()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT b.BookingID, b.CustomerID, b.RoomID,
                       c.FullName, c.Phone,
                       r.RoomNumber, rt.TypeName,
                       b.BookingDate, b.CheckInDate, b.CheckOutDate, b.Status
                FROM Bookings b
                INNER JOIN Customers  c  ON b.CustomerID  = c.CustomerID
                INNER JOIN Rooms      r  ON b.RoomID      = r.RoomID
                INNER JOIN RoomTypes  rt ON r.RoomTypeID  = rt.RoomTypeID
                ORDER BY b.BookingID ASC";
            using (MySqlConnection conn = db.GetConnection())
            {
                new MySqlDataAdapter(query, conn).Fill(dt);
            }
            return dt;
        }

        public DataTable GetCustomerList()
        {
            DataTable dt = new DataTable();
            string query = "SELECT CustomerID, FullName, Phone, Address, Email, IDCardNumber FROM Customers ORDER BY FullName";
            using (MySqlConnection conn = db.GetConnection())
            {
                new MySqlDataAdapter(query, conn).Fill(dt);
            }
            return dt;
        }

        public DataTable GetAvailableRoomList()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT r.RoomID,
                       CONCAT(rt.TypeName, ' - ', r.RoomNumber) AS FullRoomName
                FROM Rooms r
                INNER JOIN RoomTypes rt ON r.RoomTypeID = rt.RoomTypeID
                WHERE r.Status = 'Available'
                ORDER BY r.RoomNumber";
            using (MySqlConnection conn = db.GetConnection())
            {
                new MySqlDataAdapter(query, conn).Fill(dt);
            }
            return dt;
        }

        public bool CreateBooking(Booking b)
        {
            string query = @"
                INSERT INTO Bookings (CustomerID, RoomID, BookingDate, CheckInDate, CheckOutDate, Status, CreatedByAdminID)
                VALUES (@cid, @rid, @bdate, @cin, @cout, @status, @admin);
                UPDATE Rooms SET Status = 'Booked' WHERE RoomID = @rid;";
            using (MySqlConnection conn = db.GetConnection())
            {
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cid",    b.CustomerID);
                cmd.Parameters.AddWithValue("@rid",    b.RoomID);
                cmd.Parameters.AddWithValue("@bdate",  b.BookingDate);
                cmd.Parameters.AddWithValue("@cin",    b.CheckInDate);
                cmd.Parameters.AddWithValue("@cout",   b.CheckOutDate);
                cmd.Parameters.AddWithValue("@status", b.Status);
                cmd.Parameters.AddWithValue("@admin",  b.CreatedByAdminID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateBooking(Booking b)
        {
            string query = @"
                UPDATE Bookings
                SET CustomerID=@cid, RoomID=@rid, CheckInDate=@cin, CheckOutDate=@cout
                WHERE BookingID=@bid";
            using (MySqlConnection conn = db.GetConnection())
            {
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bid",  b.BookingID);
                cmd.Parameters.AddWithValue("@cid",  b.CustomerID);
                cmd.Parameters.AddWithValue("@rid",  b.RoomID);
                cmd.Parameters.AddWithValue("@cin",  b.CheckInDate);
                cmd.Parameters.AddWithValue("@cout", b.CheckOutDate);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CancelBooking(int bookingID, int roomID)
        {
            string query = @"
                UPDATE Bookings SET Status = 'Cancelled' WHERE BookingID = @bid;
                UPDATE Rooms    SET Status = 'Available' WHERE RoomID    = @rid;";
            using (MySqlConnection conn = db.GetConnection())
            {
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bid", bookingID);
                cmd.Parameters.AddWithValue("@rid", roomID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable GetBookingReport(DateTime fromDate, DateTime toDate,
                                          string roomType, string customerName)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetBookingReport", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@p_FromDate",     fromDate.Date);
                cmd.Parameters.AddWithValue("@p_ToDate",       toDate.Date);
                cmd.Parameters.AddWithValue("@p_RoomType",     string.IsNullOrWhiteSpace(roomType)     || roomType == "All" ? "" : roomType.Trim());
                cmd.Parameters.AddWithValue("@p_CustomerName", string.IsNullOrWhiteSpace(customerName) ? "" : customerName.Trim());

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            if (dt.Columns.Contains("BookingID"))   dt.Columns["BookingID"]!.ColumnName   = "booking_id";
            if (dt.Columns.Contains("FullName"))     dt.Columns["FullName"]!.ColumnName     = "customer_name";
            if (dt.Columns.Contains("Phone"))        dt.Columns["Phone"]!.ColumnName        = "phone_number";
            if (dt.Columns.Contains("Room"))         dt.Columns["Room"]!.ColumnName         = "room";
            if (dt.Columns.Contains("RoomType"))     dt.Columns["RoomType"]!.ColumnName     = "room_type";
            if (dt.Columns.Contains("CheckInDate"))  dt.Columns["CheckInDate"]!.ColumnName  = "check-in";
            if (dt.Columns.Contains("CheckOutDate")) dt.Columns["CheckOutDate"]!.ColumnName = "check-out";
            if (dt.Columns.Contains("STATUS"))       dt.Columns["STATUS"]!.ColumnName       = "status";

            return dt;
        }
    }
}
