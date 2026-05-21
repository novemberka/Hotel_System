using Hotel_System.Properties.Config;
using Hotel_System.Services;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotel_System.Report
{
    internal static class ReportDataProvider
    {
        public static DataTable Bookings()
        {
            return new BookingService().GetBookings();
        }

        public static DataTable Rooms()
        {
            return new RoomService().GetRooms();
        }

        public static DataTable Customers()
        {
            return new CustomerService().GetCustomerList();
        }

        public static DataTable Payments()
        {
            return new PaymentService().GetPaymentReport();
        }

        public static DataTable CheckIns()
        {
            return Query(@"
                SELECT
                    ci.CheckInID,
                    b.BookingID,
                    c.FullName AS CustomerName,
                    c.Phone AS PhoneNumber,
                    r.RoomNumber,
                    rt.TypeName AS RoomType,
                    ci.CheckInDate,
                    b.CheckOutDate,
                    b.Status
                FROM checkins ci
                LEFT JOIN bookings b ON b.BookingID = ci.BookingID
                INNER JOIN customers c ON c.CustomerID = ci.CustomerID
                INNER JOIN rooms r ON r.RoomID = ci.RoomID
                INNER JOIN roomtypes rt ON rt.RoomTypeID = r.RoomTypeID
                ORDER BY ci.CheckInID DESC");
        }

        public static DataTable CheckOuts()
        {
            return Query(@"
                SELECT
                    co.CheckOutID,
                    ci.CheckInID,
                    b.BookingID,
                    c.FullName AS CustomerName,
                    c.Phone AS PhoneNumber,
                    r.RoomNumber,
                    rt.TypeName AS RoomType,
                    ci.CheckInDate,
                    co.CheckOutDate,
                    co.SubTotal,
                    co.Discount,
                    co.Tax,
                    co.TotalAmount,
                    co.Deposit,
                    co.Remaining,
                    COALESCE(p.PaymentMethod, '') AS PaymentMethod,
                    COALESCE(p.PaymentStatus, '') AS PaymentStatus
                FROM checkouts co
                INNER JOIN checkins ci ON ci.CheckInID = co.CheckInID
                LEFT JOIN bookings b ON b.BookingID = ci.BookingID
                INNER JOIN customers c ON c.CustomerID = ci.CustomerID
                INNER JOIN rooms r ON r.RoomID = ci.RoomID
                INNER JOIN roomtypes rt ON rt.RoomTypeID = r.RoomTypeID
                LEFT JOIN payments p ON p.CheckOutID = co.CheckOutID
                ORDER BY co.CheckOutID DESC");
        }

        private static DataTable Query(string sql)
        {
            DataTable table = new();
            using SqlConnection connection = new DbConnection().GetConnection();
            using SqlDataAdapter adapter = new(sql, connection);
            adapter.Fill(table);
            return table;
        }
    }
}
