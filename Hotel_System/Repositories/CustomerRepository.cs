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

            string query = @"
        SELECT DISTINCT
            c.CustomerID,
            c.FullName,
            c.Gender,
            c.Phone       AS PhoneNumber,
            c.Email,
            c.IDCardNumber,
            c.Address
        FROM customers c
        LEFT JOIN bookings b   ON c.CustomerID = b.CustomerID
        LEFT JOIN rooms r      ON b.RoomID     = r.RoomID
        LEFT JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID
        WHERE 1=1";

            using (MySqlConnection conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

              
                if (fromDate.HasValue)
                {
                    query += " AND DATE(c.CreatedAt) >= @FromDate";
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Value.Date);
                }

                if (toDate.HasValue)
                {
                    query += " AND DATE(c.CreatedAt) <= @ToDate";
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Value.Date);
                }

                if (!string.IsNullOrWhiteSpace(customerName))
                {
                    query += " AND c.FullName LIKE @CustomerName";
                    cmd.Parameters.AddWithValue("@CustomerName", "%" + customerName.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(roomType))
                {
                    query += " AND rt.TypeName = @RoomType";
                    cmd.Parameters.AddWithValue("@RoomType", roomType.Trim());
                }

                if (!string.IsNullOrWhiteSpace(roomNumber))
                {
                    query += " AND r.RoomNumber = @RoomNumber";
                    cmd.Parameters.AddWithValue("@RoomNumber", roomNumber.Trim());
                }

                cmd.CommandText = query;
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