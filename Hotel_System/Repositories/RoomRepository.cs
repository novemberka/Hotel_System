using Hotel_System.Models;
using Hotel_System.Properties.Config;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hotel_System.Repositories
{
    internal class RoomRepository
    {
        private readonly DbConnection db = new DbConnection();

        public DataTable GetRoomsFromDb()
        {
            DataTable dt = new DataTable();
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

        public DataTable Search(string keyword)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT r.RoomID, r.RoomNumber, rt.TypeName, rt.PricePerNight, r.Status
                     FROM rooms r
                     INNER JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID
                     WHERE r.RoomNumber LIKE @key";

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@key", "%" + keyword + "%");
                adapter.Fill(dt);
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

        public DataTable GetRoomTypes()
        {
            DataTable dt = new DataTable();
            string query = "SELECT RoomTypeID, TypeName, PricePerNight FROM roomtypes";

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetRoomReport(string roomNumber, string floor, string roomType)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetRoomReport", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@p_FromDate",   System.DBNull.Value);
                cmd.Parameters.AddWithValue("@p_ToDate",     System.DBNull.Value);
                cmd.Parameters.AddWithValue("@p_RoomType",   string.IsNullOrWhiteSpace(roomType) || roomType == "All" ? "" : roomType.Trim());
                cmd.Parameters.AddWithValue("@p_RoomNumber", string.IsNullOrWhiteSpace(roomNumber) ? "" : roomNumber.Trim());
                cmd.Parameters.AddWithValue("@p_Floor",      string.IsNullOrWhiteSpace(floor) ? "" : floor.Trim());

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
