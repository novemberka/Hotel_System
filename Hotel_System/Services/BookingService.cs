using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Services
{
    internal class BookingService
    {
        string connStr = "server=localhost;database=hotel_db;uid=root;pwd=;";

        public DataTable GetWalkInReport(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("sp_WalkInReport", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("FromDate", fromDate);
                    cmd.Parameters.AddWithValue("ToDate", toDate);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
    }
}
