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
            string query = @"SELECT r.RoomID,
                     CONCAT('Room ', r.RoomNumber, ' - ', rt.TypeName, ' ($', rt.PricePerNight, '/night)') AS FullRoomName,
                     rt.PricePerNight
                     FROM rooms r
                     INNER JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID
                     WHERE r.Status = 'Available'";
            using (MySqlConnection conn = db.GetConnection())
            {
                new MySqlDataAdapter(query, conn).Fill(dt);
            }
            return dt;
        }

        public bool Add(Booking booking)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO bookings
                    (CustomerID, RoomID, BookingDate, CheckInDate, CheckOutDate, Status, CreatedByAdminID)
                    VALUES (@cID, @rID, @bDate, @in, @out, @stat, @aID)";

                        MySqlCommand cmd = new MySqlCommand(query, conn, trans);
                        cmd.Parameters.Add("@cID",   MySqlDbType.Int32).Value    = booking.CustomerID;
                        cmd.Parameters.Add("@rID",   MySqlDbType.Int32).Value    = booking.RoomID;
                        cmd.Parameters.Add("@bDate", MySqlDbType.DateTime).Value = booking.BookingDate;
                        cmd.Parameters.Add("@in",    MySqlDbType.DateTime).Value = booking.CheckInDate;
                        cmd.Parameters.Add("@out",   MySqlDbType.DateTime).Value = booking.CheckOutDate;
                        cmd.Parameters.Add("@stat",  MySqlDbType.VarChar).Value  = booking.Status ?? "Pending";
                        cmd.Parameters.Add("@aID",   MySqlDbType.Int32).Value    = booking.CreatedByAdminID == 0 ? 1 : booking.CreatedByAdminID;
                        cmd.ExecuteNonQuery();

                        string roomQuery = "UPDATE rooms SET Status = 'Reserved' WHERE RoomID = @rID";
                        MySqlCommand roomCmd = new MySqlCommand(roomQuery, conn, trans);
                        roomCmd.Parameters.AddWithValue("@rID", booking.RoomID);
                        roomCmd.ExecuteNonQuery();

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new Exception("Database Error: " + ex.Message);
                    }
                }
            }
        }

        public bool UpdateBooking(Booking booking)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        int oldRoomId = 0;
                        string getOldRoomQuery = "SELECT RoomID FROM bookings WHERE BookingID = @bID";
                        using (MySqlCommand cmdOld = new MySqlCommand(getOldRoomQuery, conn, trans))
                        {
                            cmdOld.Parameters.AddWithValue("@bID", booking.BookingID);
                            var result = cmdOld.ExecuteScalar();
                            if (result != null) oldRoomId = Convert.ToInt32(result);
                        }

                        string updateQuery = @"UPDATE bookings SET
                    CustomerID = @cID, RoomID = @rID,
                    CheckInDate = @inDate, CheckOutDate = @outDate, Status = @status
                    WHERE BookingID = @bID";

                        MySqlCommand cmd = new MySqlCommand(updateQuery, conn, trans);
                        cmd.Parameters.AddWithValue("@cID",     booking.CustomerID);
                        cmd.Parameters.AddWithValue("@rID",     booking.RoomID);
                        cmd.Parameters.AddWithValue("@inDate",  booking.CheckInDate);
                        cmd.Parameters.AddWithValue("@outDate", booking.CheckOutDate);
                        cmd.Parameters.AddWithValue("@status",  booking.Status);
                        cmd.Parameters.AddWithValue("@bID",     booking.BookingID);
                        cmd.ExecuteNonQuery();

                        if (oldRoomId != booking.RoomID && oldRoomId != 0)
                        {
                            string releaseOld = "UPDATE rooms SET Status = 'Available' WHERE RoomID = @oldID";
                            MySqlCommand cmdRelease = new MySqlCommand(releaseOld, conn, trans);
                            cmdRelease.Parameters.AddWithValue("@oldID", oldRoomId);
                            cmdRelease.ExecuteNonQuery();
                        }

                        string currentRoomStatus = booking.Status switch
                        {
                            "Pending"    => "Reserved",
                            "Confirmed"  => "Occupied",
                            _            => "Available"
                        };

                        string updateCurrentRoom = "UPDATE rooms SET Status = @stat WHERE RoomID = @rID";
                        MySqlCommand cmdCurrent = new MySqlCommand(updateCurrentRoom, conn, trans);
                        cmdCurrent.Parameters.AddWithValue("@stat", currentRoomStatus);
                        cmdCurrent.Parameters.AddWithValue("@rID",  booking.RoomID);
                        cmdCurrent.ExecuteNonQuery();

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new Exception("Update Failed: " + ex.Message);
                    }
                }
            }
        }

        public DataTable GetCustomersForBooking()
        {
            DataTable dt = new DataTable();
            string query = "SELECT CustomerID, FullName, Phone, Address, Email, IDCardNumber FROM customers";
            using (MySqlConnection conn = db.GetConnection())
            {
                new MySqlDataAdapter(query, conn).Fill(dt);
            }
            return dt;
        }

        public bool UpdateStatusAndReleaseRoom(int bookingId, int roomId, string newStatus)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string cancelQuery = "UPDATE bookings SET Status = @status WHERE BookingID = @bID";
                        MySqlCommand cmdCancel = new MySqlCommand(cancelQuery, conn, trans);
                        cmdCancel.Parameters.AddWithValue("@status", newStatus);
                        cmdCancel.Parameters.AddWithValue("@bID", bookingId);
                        cmdCancel.ExecuteNonQuery();

                        string roomQuery = "UPDATE rooms SET Status = 'Available' WHERE RoomID = @rID";
                        MySqlCommand cmdRoom = new MySqlCommand(roomQuery, conn, trans);
                        cmdRoom.Parameters.AddWithValue("@rID", roomId);
                        cmdRoom.ExecuteNonQuery();

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new Exception("Cancellation failed: " + ex.Message);
                    }
                }
            }
        }

        public string GetBookingStatus(int bookingId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT Status FROM bookings WHERE BookingID = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", bookingId);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "";
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
