
using System;
using System.Data;
using MySql.Data.MySqlClient;
using Hotel_System.Models;
using Hotel_System.Properties.Config;

namespace Hotel_System.Repositories
{
    internal class CheckinCheckoutRepository
    {
        private DbConnection db = new DbConnection();

        public DataTable GetBookingDetails(int bookingId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                // We select the IDs specifically so we can store them in the UI
                string query = @"SELECT 
                                b.BookingID,
                                b.CustomerID,
                                b.RoomID,
                                b.Status,
                                b.CheckInDate,
                                b.CheckOutDate,
                                c.FullName,
                                r.RoomNumber,
                                rt.PricePerNight
                            FROM bookings b
                            JOIN customers c ON b.CustomerID = c.CustomerID
                            JOIN rooms r ON b.RoomID = r.RoomID
                            JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID
                            WHERE b.BookingID = @id";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@id", bookingId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public DataTable GetAllOperations()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"SELECT 
                            b.BookingID,
                            c.FullName AS Customer,
                            r.RoomNumber AS Room,
                            b.CheckInDate,
                            b.CheckOutDate,
                            ((DATEDIFF(b.CheckOutDate, b.CheckInDate)) * rt.PricePerNight) AS TotalPrice,
                            b.Status
                         FROM bookings b
                         JOIN customers c 
                            ON b.CustomerID = c.CustomerID
                         JOIN rooms r 
                            ON b.RoomID = r.RoomID
                         JOIN roomtypes rt 
                            ON r.RoomTypeID = rt.RoomTypeID
                         WHERE TRIM(b.Status) IN ('Pending', 'CheckIn', 'CheckOut')
                         ORDER BY b.BookingID DESC";

                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(query, conn);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                return dt;
            }
        }
        // 1. Perform Check-In
        public bool PerformCheckIn(CheckIn ci)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert into checkins table
                        string q1 = @"INSERT INTO checkins (BookingID, CustomerID, RoomID, CheckInDate, CreatedByAdminID) 
                             VALUES (@bID, @cID, @rID, @date, @aID)";
                        MySqlCommand cmd1 = new MySqlCommand(q1, conn, trans);
                        cmd1.Parameters.AddWithValue("@bID", ci.BookingID);
                        cmd1.Parameters.AddWithValue("@cID", ci.CustomerID);
                        cmd1.Parameters.AddWithValue("@rID", ci.RoomID);
                        cmd1.Parameters.AddWithValue("@date", ci.CheckInDate);
                        cmd1.Parameters.AddWithValue("@aID", ci.CreatedByAdminID);
                        cmd1.ExecuteNonQuery();

                        // 2. Update Booking Status (MUST BE 'bookings' table)
                        string q2 = "UPDATE bookings SET Status = @status WHERE BookingID = @bookingID";
                        MySqlCommand cmd2 = new MySqlCommand(q2, conn, trans);
                        cmd2.Parameters.AddWithValue("@status", "CheckIn"); // The string you want
                        cmd2.Parameters.AddWithValue("@bookingID", ci.BookingID);
                        cmd2.ExecuteNonQuery();

                        // 3. Update Room Status (MUST BE 'rooms' table)
                        string q3 = "UPDATE rooms SET Status = 'Occupied' WHERE RoomID = @roomID";
                        MySqlCommand cmd3 = new MySqlCommand(q3, conn, trans);
                        cmd3.Parameters.AddWithValue("@roomID", ci.RoomID);
                        cmd3.ExecuteNonQuery();

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
        public bool PerformCheckOut(int bookingID, int roomID, decimal totalAmount, int adminID)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Get the CheckInID first (needed for the checkouts table)
                        string getCheckIn = "SELECT CheckInID FROM checkins WHERE BookingID = @bID LIMIT 1";
                        MySqlCommand cmdGet = new MySqlCommand(getCheckIn, conn, trans);
                        cmdGet.Parameters.AddWithValue("@bID", bookingID);
                        object checkInObj = cmdGet.ExecuteScalar();

                        if (checkInObj == null) throw new Exception("No Check-In record found for this booking.");
                        int checkInID = Convert.ToInt32(checkInObj);

                        // 2. INSERT into checkouts table (THIS WAS MISSING)
                        string qInsert = @"INSERT INTO checkouts (CheckInID, CheckOutDate, TotalAmount, CreatedByAdminID) 
                        VALUES (@ciID, NOW(), @total, @aID)";
                        MySqlCommand cmdInsert = new MySqlCommand(qInsert, conn, trans);
                        cmdInsert.Parameters.AddWithValue("@ciID", checkInID);
                        cmdInsert.Parameters.AddWithValue("@total", totalAmount);
                        cmdInsert.Parameters.AddWithValue("@aID", adminID);
                        cmdInsert.ExecuteNonQuery();

                        // 3. Update booking status
                        string qStatus = "UPDATE bookings SET Status='CheckOut' WHERE BookingID=@id";
                        MySqlCommand cmdStatus = new MySqlCommand(qStatus, conn, trans);
                        cmdStatus.Parameters.AddWithValue("@id", bookingID);
                        cmdStatus.ExecuteNonQuery();

                        // 4. Update room status
                        string qRoom = "UPDATE rooms SET Status='Available' WHERE RoomID=@roomID";
                        MySqlCommand cmdRoom = new MySqlCommand(qRoom, conn, trans);
                        cmdRoom.Parameters.AddWithValue("@roomID", roomID);
                        cmdRoom.ExecuteNonQuery();

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new Exception("Checkout Failed: " + ex.Message);
                    }
                }
            }
        }
        public bool UpdateBookingStatus(int bookingID,
    string status,
    DateTime checkIn,
    DateTime checkOut)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"UPDATE bookings
                         SET Status=@status,
                             CheckInDate=@checkIn,
                             CheckOutDate=@checkOut
                         WHERE BookingID=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@checkIn", checkIn);
                cmd.Parameters.AddWithValue("@checkOut", checkOut);
                cmd.Parameters.AddWithValue("@id", bookingID);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public DataTable GetAllPendingBookingIDs()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"SELECT BookingID 
                         FROM bookings
                         WHERE (Status IN ('Pending', 'CheckIn') 
                           OR Status = '' 
                           OR Status IS NULL)
                         ORDER BY BookingID DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }


    }
}
