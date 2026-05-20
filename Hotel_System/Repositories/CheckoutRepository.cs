using Hotel_System.Properties.Config;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Hotel_System.Repositories
{
    internal class CheckoutRepository
    {
        private readonly DbConnection db = new DbConnection();

        public DataTable GetCheckOutReport(DateTime fromDate, DateTime toDate, string roomType)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetCheckInCheckOutReport", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@p_FromDate",     fromDate.Date);
                cmd.Parameters.AddWithValue("@p_ToDate",       toDate.Date);
                cmd.Parameters.AddWithValue("@p_RoomType",     string.IsNullOrWhiteSpace(roomType) || roomType == "All" ? (object)DBNull.Value : roomType.Trim());
                cmd.Parameters.AddWithValue("@p_CustomerName", DBNull.Value);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            // Rename SP output columns to match DataGridView DataPropertyName bindings
            if (dt.Columns.Contains("CustomerName"))  dt.Columns["CustomerName"].ColumnName  = "customer_name";
            if (dt.Columns.Contains("PhoneNumber"))   dt.Columns["PhoneNumber"].ColumnName   = "phone_number";
            if (dt.Columns.Contains("Room"))          dt.Columns["Room"].ColumnName          = "room";
            if (dt.Columns.Contains("RoomType"))      dt.Columns["RoomType"].ColumnName      = "room_type";
            if (dt.Columns.Contains("RoomNumber"))    dt.Columns["RoomNumber"].ColumnName    = "room_number";
            if (dt.Columns.Contains("ID/Passport"))   dt.Columns["ID/Passport"].ColumnName   = "id_passport";
            if (dt.Columns.Contains("Check In"))      dt.Columns["Check In"].ColumnName      = "check-in";
            if (dt.Columns.Contains("Check Out"))     dt.Columns["Check Out"].ColumnName     = "check-out";


            return dt;
        }
    }
}
