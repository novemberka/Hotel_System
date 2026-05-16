using Hotel_System.Properties.Config;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Hotel_System.Repositories
{
    internal class BookingRepository
    {
        private readonly DbConnection db = new DbConnection();

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
