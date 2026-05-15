using Hotel_System.Properties.Config;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Hotel_System.Repositories
{
    internal class BookingRepository
    {
        private readonly DbConnection db = new DbConnection();

        public DataTable GetBookingReport(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand("sp_WalkInReport", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            // Rename SP output columns to match DataGridView DataPropertyName bindings
            if (dt.Columns.Contains("FullName"))     dt.Columns["FullName"]!.ColumnName     = "customer_name";
            if (dt.Columns.Contains("Phone"))        dt.Columns["Phone"]!.ColumnName        = "phone_number";
            if (dt.Columns.Contains("RoomType"))     dt.Columns["RoomType"]!.ColumnName     = "room_type";
            if (dt.Columns.Contains("CheckInDate"))  dt.Columns["CheckInDate"]!.ColumnName  = "check-in";
            if (dt.Columns.Contains("CheckOutDate")) dt.Columns["CheckOutDate"]!.ColumnName = "check-out";

            return dt;
        }
    }
}
