using Hotel_System.Models;
using Hotel_System.Properties.Config;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Hotel_System.Repositories
{
    internal class CustomerRepository
    {
        private DbConnection db = new DbConnection();

        public bool Save(Customer customer)
        {
            string query = "INSERT INTO customers (FullName, Gender, Phone, Email, Address, IDCardNumber) " +
                           "VALUES (@name, @gender, @phone, @email, @address, @idcard)";

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", customer.FullName);
                    cmd.Parameters.AddWithValue("@gender", customer.Gender);
                    cmd.Parameters.AddWithValue("@phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@address", customer.Address);
                    cmd.Parameters.AddWithValue("@idcard", customer.IDCardNumber);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM customers";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public bool Update(Customer customer)
        {
            string query = "UPDATE customers SET FullName=@name, Gender=@gender, Phone=@phone, " +
                           "Email=@email, Address=@address, IDCardNumber=@idcard WHERE CustomerID=@id";

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", customer.CustomerID);
                    cmd.Parameters.AddWithValue("@name", customer.FullName);
                    cmd.Parameters.AddWithValue("@gender", customer.Gender);
                    cmd.Parameters.AddWithValue("@phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@address", customer.Address);
                    cmd.Parameters.AddWithValue("@idcard", customer.IDCardNumber);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM customers WHERE CustomerID=@id";
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

        public DataTable GetCustomerReport(DateTime? fromDate, DateTime? toDate,
                               string customerName, string roomType, string roomNumber)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetCustomerReport", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@p_FromDate",     fromDate.HasValue ? (object)fromDate.Value.Date : DBNull.Value);
                cmd.Parameters.AddWithValue("@p_ToDate",       toDate.HasValue   ? (object)toDate.Value.Date   : DBNull.Value);
                cmd.Parameters.AddWithValue("@p_RoomType",     string.IsNullOrWhiteSpace(roomType)     ? (object)DBNull.Value : roomType.Trim());
                cmd.Parameters.AddWithValue("@p_CustomerName", string.IsNullOrWhiteSpace(customerName) ? (object)DBNull.Value : customerName.Trim());

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        public DataTable GetAllRoomTypes()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT RoomTypeID, TypeName FROM roomtypes ORDER BY TypeName";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
