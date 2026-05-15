using System;
using System.Data;
using MySql.Data.MySqlClient;
using Hotel_System.Models;
using Hotel_System.Properties.Config;

namespace Hotel_System.Repositories
{
    internal class BookingRepository
    {
        private DbConnection db = new DbConnection();

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
                        // Use explicit types to avoid mapping issues
                        cmd.Parameters.Add("@cID", MySqlDbType.Int32).Value = booking.CustomerID;
                        cmd.Parameters.Add("@rID", MySqlDbType.Int32).Value = booking.RoomID;
                        cmd.Parameters.Add("@bDate", MySqlDbType.DateTime).Value = booking.BookingDate;
                        cmd.Parameters.Add("@in", MySqlDbType.DateTime).Value = booking.CheckInDate;
                        cmd.Parameters.Add("@out", MySqlDbType.DateTime).Value = booking.CheckOutDate;
                        cmd.Parameters.Add("@stat", MySqlDbType.VarChar).Value = booking.Status ?? "Pending";
                        cmd.Parameters.Add("@aID", MySqlDbType.Int32).Value = booking.CreatedByAdminID == 0 ? 1 : booking.CreatedByAdminID;

                        cmd.ExecuteNonQuery();

                        // Update room status to 'Occupied'
                        string roomQuery = "UPDATE rooms SET Status = 'Occupied' WHERE RoomID = @rID";
                        MySqlCommand roomCmd = new MySqlCommand(roomQuery, conn, trans);
                        roomCmd.Parameters.AddWithValue("@rID", booking.RoomID);
                        roomCmd.ExecuteNonQuery();

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        // This will tell you if it's a Foreign Key error or a Null error
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
                        // 1. Get the OLD RoomID before we overwrite it
                        int oldRoomId = 0;
                        string getOldRoomQuery = "SELECT RoomID FROM bookings WHERE BookingID = @bID";
                        using (MySqlCommand cmdOld = new MySqlCommand(getOldRoomQuery, conn, trans))
                        {
                            cmdOld.Parameters.AddWithValue("@bID", booking.BookingID);
                            var result = cmdOld.ExecuteScalar();
                            if (result != null) oldRoomId = Convert.ToInt32(result);
                        }

                        // 2. Update the Booking details
                        string updateQuery = @"UPDATE bookings SET 
                    CustomerID = @cID, RoomID = @rID, 
                    CheckInDate = @inDate, CheckOutDate = @outDate, Status = @status
                    WHERE BookingID = @bID";

                        MySqlCommand cmd = new MySqlCommand(updateQuery, conn, trans);
                        cmd.Parameters.AddWithValue("@cID", booking.CustomerID);
                        cmd.Parameters.AddWithValue("@rID", booking.RoomID);
                        cmd.Parameters.AddWithValue("@inDate", booking.CheckInDate);
                        cmd.Parameters.AddWithValue("@outDate", booking.CheckOutDate);
                        cmd.Parameters.AddWithValue("@status", booking.Status);
                        cmd.Parameters.AddWithValue("@bID", booking.BookingID);
                        cmd.ExecuteNonQuery();

                        // 3. Handle Room Status Logic
                        // If room changed: Make OLD available, Make NEW occupied
                        if (oldRoomId != booking.RoomID && oldRoomId != 0)
                        {
                            string releaseOld = "UPDATE rooms SET Status = 'Available' WHERE RoomID = @oldID";
                            MySqlCommand cmdRelease = new MySqlCommand(releaseOld, conn, trans);
                            cmdRelease.Parameters.AddWithValue("@oldID", oldRoomId);
                            cmdRelease.ExecuteNonQuery();
                        }

                        // Set status for the CURRENT room (the one in the model)
                        string currentRoomStatus = (booking.Status == "Complete" || booking.Status == "Cancelled")
                                                    ? "Available" : "Occupied";

                        string updateCurrentRoom = "UPDATE rooms SET Status = @stat WHERE RoomID = @rID";
                        MySqlCommand cmdCurrent = new MySqlCommand(updateCurrentRoom, conn, trans);
                        cmdCurrent.Parameters.AddWithValue("@stat", currentRoomStatus);
                        cmdCurrent.Parameters.AddWithValue("@rID", booking.RoomID);
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

        // Helper to get Customer Details for the Top Panel in image_188ba2.png
        public DataTable GetCustomersForBooking()
        {
            DataTable dt = new DataTable();
            string query = "SELECT CustomerID, FullName, Phone, Address, Email, IDCardNumber FROM customers";
            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
        public DataTable GetAvailableRoomList()
        {
            DataTable dt = new DataTable();
            // This creates exactly: "Room 102 - standard ($120/night)"
            string query = @"SELECT r.RoomID, 
                     CONCAT('Room ', r.RoomNumber, ' - ', rt.TypeName, ' ($', rt.PricePerNight, '/night)') AS FullRoomName,
                     rt.PricePerNight
                     FROM rooms r
                     INNER JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID
                     WHERE r.Status = 'Available'";

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
                    // 1. Insert the Booking record
                    string bookingQuery = @"INSERT INTO bookings 
                (CustomerID, RoomID, BookingDate, CheckInDate, CheckOutDate, Status, CreatedByAdminID) 
                VALUES (@cID, @rID, @bDate, @inDate, @outDate, @stat, @aID)";

                    MySqlCommand cmdBook = new MySqlCommand(bookingQuery, conn, trans);
                    cmdBook.Parameters.AddWithValue("@cID", booking.CustomerID);
                    cmdBook.Parameters.AddWithValue("@rID", booking.RoomID);
                    cmdBook.Parameters.AddWithValue("@bDate", DateTime.Now);
                    cmdBook.Parameters.AddWithValue("@inDate", booking.CheckInDate);
                    cmdBook.Parameters.AddWithValue("@outDate", booking.CheckOutDate);
                    cmdBook.Parameters.AddWithValue("@stat", "Confirmed");
                    cmdBook.Parameters.AddWithValue("@aID", 1); // Replace with logged-in admin ID
                    cmdBook.ExecuteNonQuery();

                    // 2. Update the Room Status to 'Occupied'
                    string roomQuery = "UPDATE rooms SET Status = 'Occupied' WHERE RoomID = @rID";
                    MySqlCommand cmdRoom = new MySqlCommand(roomQuery, conn, trans);
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

        // Update status to 'Confirmed' when user performs Check-In
        public bool ConfirmCheckIn(int bookingId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    string query = "UPDATE bookings SET Status = 'Confirmed' WHERE BookingID = @bID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@bID", bookingId);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Check-in Error: " + ex.Message);
                }
            }
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
                        // 1. Update Booking Status to Cancelled
                        string cancelQuery = "UPDATE bookings SET Status = 'Cancelled' WHERE BookingID = @bID";
                        MySqlCommand cmdCancel = new MySqlCommand(cancelQuery, conn, trans);
                        cmdCancel.Parameters.AddWithValue("@bID", bookingId);
                        cmdCancel.ExecuteNonQuery();

                        // 2. Update Room Status back to Available
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

    }
}