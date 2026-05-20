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

        public DataTable GetBookingsFromDb()
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT 
                    b.BookingID,
                    b.CustomerID,
                    c.FullName,
                    b.RoomID,
                    r.RoomNumber,
                    b.BookingDate,
                    b.CheckInDate,
                    b.CheckOutDate,
                    b.Status
                FROM bookings b
                INNER JOIN customers c ON b.CustomerID = c.CustomerID
                INNER JOIN rooms r ON b.RoomID = r.RoomID";

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            return dt;
        }

        public DataTable GetCustomerList()
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT 
                    CustomerID,
                    FullName,
                    Phone,
                    Address,
                    Email,
                    IDCardNumber
                FROM customers
                ORDER BY FullName";

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            return dt;
        }


        public bool SaveBooking(Booking booking)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string bookingQuery = @"
                        INSERT INTO bookings
                        (
                            CustomerID,
                            RoomID,
                            BookingDate,
                            CheckInDate,
                            CheckOutDate,
                            Status,
                            CreatedByAdminID
                        )
                        VALUES
                        (
                            @cID,
                            @rID,
                            @bDate,
                            @inDate,
                            @outDate,
                            @stat,
                            @aID
                        )";

                    MySqlCommand cmdBook =
                        new MySqlCommand(bookingQuery, conn, trans);

                    cmdBook.Parameters.AddWithValue("@cID", booking.CustomerID);
                    cmdBook.Parameters.AddWithValue("@rID", booking.RoomID);
                    cmdBook.Parameters.AddWithValue("@bDate", booking.BookingDate);
                    cmdBook.Parameters.AddWithValue("@inDate", booking.CheckInDate);
                    cmdBook.Parameters.AddWithValue("@outDate", booking.CheckOutDate);
                    cmdBook.Parameters.AddWithValue("@stat", booking.Status);
                    cmdBook.Parameters.AddWithValue("@aID", booking.CreatedByAdminID);

                    cmdBook.ExecuteNonQuery();

                    // Update room status
                    string roomQuery =
                        "UPDATE rooms SET Status='Reserved' WHERE RoomID=@rID";

                    MySqlCommand cmdRoom =
                        new MySqlCommand(roomQuery, conn, trans);

                    cmdRoom.Parameters.AddWithValue("@rID", booking.RoomID);

                    cmdRoom.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }


        public bool UpdateBooking(Booking b)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string query = @"
                        UPDATE bookings
                        SET
                            CustomerID = @cid,
                            RoomID = @rid,
                            CheckInDate = @cin,
                            CheckOutDate = @cout,
                            Status = @status
                        WHERE BookingID = @bid";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn, trans);

                    cmd.Parameters.AddWithValue("@cid", b.CustomerID);
                    cmd.Parameters.AddWithValue("@rid", b.RoomID);
                    cmd.Parameters.AddWithValue("@cin", b.CheckInDate);
                    cmd.Parameters.AddWithValue("@cout", b.CheckOutDate);
                    cmd.Parameters.AddWithValue("@status", b.Status);
                    cmd.Parameters.AddWithValue("@bid", b.BookingID);

                    cmd.ExecuteNonQuery();

                    // Room status logic
                    string roomStatus = "Available";

                    if (b.Status == "Pending")
                        roomStatus = "Reserved";
                    else if (b.Status == "Confirmed")
                        roomStatus = "Occupied";
                    else if (b.Status == "Cancelled" ||
                             b.Status == "CheckedOut")
                        roomStatus = "Available";

                    string roomQuery =
                        "UPDATE rooms SET Status=@status WHERE RoomID=@rid";

                    MySqlCommand roomCmd =
                        new MySqlCommand(roomQuery, conn, trans);

                    roomCmd.Parameters.AddWithValue("@status", roomStatus);
                    roomCmd.Parameters.AddWithValue("@rid", b.RoomID);

                    roomCmd.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
        public DataTable GetAvailableRoomList()
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT 
                    r.RoomID,
                    CONCAT(rt.TypeName, ' - ', r.RoomNumber) AS FullRoomName
                FROM rooms r
                INNER JOIN roomtypes rt
                    ON r.RoomTypeID = rt.RoomTypeID
                WHERE r.Status = 'Available'
                ORDER BY r.RoomNumber";

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(query, conn);

                adapter.Fill(dt);
            }

            return dt;
        }
        public bool UpdateStatusAndReleaseRoom(
            int bookingId,
            int roomId,
            string newStatus)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string bookingQuery = @"
                        UPDATE bookings
                        SET Status=@status
                        WHERE BookingID=@bid";

                    MySqlCommand cmdBooking =
                        new MySqlCommand(bookingQuery, conn, trans);

                    cmdBooking.Parameters.AddWithValue("@status", newStatus);
                    cmdBooking.Parameters.AddWithValue("@bid", bookingId);

                    cmdBooking.ExecuteNonQuery();

                    string roomQuery = @"
                        UPDATE rooms
                        SET Status='Available'
                        WHERE RoomID=@rid";

                    MySqlCommand cmdRoom =
                        new MySqlCommand(roomQuery, conn, trans);

                    cmdRoom.Parameters.AddWithValue("@rid", roomId);

                    cmdRoom.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
        public DataTable GetBookingReport(
    DateTime fromDate,
    DateTime toDate,
    string roomType = "",
    string customerName = "")
        {
            DataTable dt = new DataTable();

            // FIXED: Changed the date logic to find overlapping or active bookings in the range
            string query = @"
        SELECT
            b.BookingID,
            c.FullName AS CustomerName,
            c.Phone AS PhoneNumber,
            CONCAT(rt.TypeName, ' - ', r.RoomNumber) AS Room,
            rt.TypeName AS RoomType,
            b.CheckInDate AS CheckIn,
            b.CheckOutDate AS CheckOut,
            b.Status,
            IFNULL(SUM(p.AmountPaid), 0) AS TotalAmount
        FROM bookings b
        INNER JOIN customers c ON b.CustomerID = c.CustomerID
        INNER JOIN rooms r ON b.RoomID = r.RoomID
        INNER JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID
        LEFT JOIN payments p ON b.BookingID = p.BookingID
        WHERE DATE(b.CheckInDate) <= @toDate 
          AND DATE(b.CheckOutDate) >= @fromDate";

            // Append standard WHERE filters
            if (!string.IsNullOrWhiteSpace(roomType) && roomType != "All")
            {
                query += " AND rt.TypeName = @roomType";
            }

            if (!string.IsNullOrWhiteSpace(customerName))
            {
                query += " AND c.FullName LIKE @customerName";
            }

            // Append GROUP BY strictly AFTER all WHERE conditions
            query += " GROUP BY b.BookingID;";

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@toDate", toDate.Date);

                if (!string.IsNullOrWhiteSpace(roomType) && roomType != "All")
                {
                    cmd.Parameters.AddWithValue("@roomType", roomType);
                }

                if (!string.IsNullOrWhiteSpace(customerName))
                {
                    cmd.Parameters.AddWithValue("@customerName", "%" + customerName + "%");
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }
        public string GetBookingStatus(int bookingID)
        {
            string status = "";

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT Status
            FROM bookings
            WHERE BookingID = @id";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", bookingID);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    status = result.ToString();
                }
            }

            return status;
        }
    }
}