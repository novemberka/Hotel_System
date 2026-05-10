using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_System.Models;
using Hotel_System.Properties.Config;
using MySql.Data.MySqlClient;

namespace Hotel_System.Repositories
{
    internal class RoomRepository
    {
        private DbConnection db = new DbConnection();
        public DataTable GetRoomsFromDb()
        {
            DataTable dt = new DataTable();
            // This query grabs data from BOTH tables at the same time
            string query = @"SELECT 
                        r.RoomID, 
                        r.RoomNumber, 
                        r.RoomTypeID,
                        rt.TypeName, 
                        rt.PricePerNight, 
                        r.Status 
                     FROM rooms r 
                     INNER JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID";

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Search(string roomNumber, string roomId, string status)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                r.RoomID,
                r.RoomNumber,
                rt.TypeName,
                rt.PricePerNight,
                r.Status,
                r.RoomTypeID
            FROM rooms r
            INNER JOIN roomtypes rt 
                ON r.RoomTypeID = rt.RoomTypeID
            WHERE 
                (@RoomNumber = '' OR r.RoomNumber LIKE CONCAT('%', @RoomNumber, '%'))
                AND (@RoomID = '' OR CAST(r.RoomID AS CHAR) LIKE CONCAT('%', @RoomID, '%'))
                AND (@Status = '' OR r.Status = @Status)
        ";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomNumber", roomNumber ?? "");
                    cmd.Parameters.AddWithValue("@RoomID", roomId ?? "");
                    cmd.Parameters.AddWithValue("@Status", status ?? "");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
        public bool Add(Room room)
        {
            string query = "INSERT INTO rooms (RoomNumber, RoomTypeID, Status) VALUES (@num, @type, @status)";

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@num", room.RoomNumber);
                    cmd.Parameters.AddWithValue("@type", room.RoomTypeID);
                    cmd.Parameters.AddWithValue("@status", room.Status);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(Room room)
        {
            string query = "UPDATE rooms SET RoomNumber=@num, RoomTypeID=@type, Status=@status WHERE RoomID=@id";
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", room.RoomID);
                    cmd.Parameters.AddWithValue("@num", room.RoomNumber);
                    cmd.Parameters.AddWithValue("@type", room.RoomTypeID);
                    cmd.Parameters.AddWithValue("@status", room.Status);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM rooms WHERE RoomID=@id";
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private bool ExecuteQuery(string query, Room room)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", room.RoomID);
                    cmd.Parameters.AddWithValue("@num", room.RoomNumber);
                    cmd.Parameters.AddWithValue("@type", room.RoomTypeID);
                    cmd.Parameters.AddWithValue("@status", room.Status);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable GetRoomTypes()
        {
            DataTable dt = new DataTable();
            // CRITICAL: You MUST include 'Floor' and 'PricePerNight' here
            string query = "SELECT RoomTypeID, TypeName, PricePerNight FROM roomtypes";

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

    }
}
