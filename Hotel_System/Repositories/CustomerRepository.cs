using Hotel_System.Models;
using Hotel_System.Properties.Config;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Hotel_System.Repositories
{
    internal class CustomerRepository
    {
        private readonly DbConnection db = new DbConnection();

        public bool Save(Customer customer)
        {
            string query = "INSERT INTO customers (FullName, Gender, Phone, Email, Address, IDCardNumber) " +
                           "VALUES (@name, @gender, @phone, @email, @address, @idcard)";

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
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
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"
                    SELECT CustomerID, FullName, Gender, Phone, Email, Address, IDCardNumber, CreatedAt
                    FROM customers
                    ORDER BY CustomerID DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public Customer? FindByPhone(string phone)
        {
            using SqlConnection conn = db.GetConnection();
            conn.Open();

            using SqlCommand cmd = new SqlCommand(@"
                SELECT TOP 1 CustomerID, FullName, Gender, Phone, Email, Address, IDCardNumber
                FROM customers
                WHERE Phone = @phone
                ORDER BY CustomerID DESC", conn);
            cmd.Parameters.AddWithValue("@phone", phone.Trim());

            using SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            return new Customer
            {
                CustomerID = reader["CustomerID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CustomerID"]),
                FullName = reader["FullName"]?.ToString() ?? string.Empty,
                Gender = reader["Gender"]?.ToString() ?? string.Empty,
                Phone = reader["Phone"]?.ToString() ?? string.Empty,
                Email = reader["Email"]?.ToString() ?? string.Empty,
                Address = reader["Address"]?.ToString() ?? string.Empty,
                IDCardNumber = reader["IDCardNumber"]?.ToString() ?? string.Empty
            };
        }

        public CustomerBookingLookup? FindLatestBookingByPhone(string phone)
        {
            using SqlConnection conn = db.GetConnection();
            conn.Open();

            using SqlCommand cmd = new SqlCommand(@"
                SELECT TOP 1
                    c.CustomerID,
                    c.FullName,
                    c.Gender,
                    c.Phone,
                    c.Email,
                    c.Address,
                    c.IDCardNumber,
                    b.BookingID,
                    b.RoomID,
                    b.CheckInDate,
                    b.CheckOutDate,
                    b.Status AS BookingStatus,
                    b.TotalPrice,
                    b.Deposit,
                    r.RoomNumber,
                    r.PricePerNight,
                    rt.TypeName AS RoomType
                FROM customers c
                LEFT JOIN bookings b ON b.CustomerID = c.CustomerID
                LEFT JOIN rooms r ON r.RoomID = b.RoomID
                LEFT JOIN roomtypes rt ON rt.RoomTypeID = r.RoomTypeID
                WHERE c.Phone = @phone
                ORDER BY
                    CASE
                        WHEN b.Status = 'Reserved' THEN 0
                        WHEN b.Status = 'Booked' THEN 1
                        WHEN b.Status = 'Checked In' THEN 2
                        WHEN b.Status = 'Checked Out' THEN 3
                        WHEN b.Status = 'Completed' THEN 4
                        WHEN b.Status = 'Cancelled' THEN 5
                        ELSE 3
                    END,
                    b.CheckInDate DESC,
                    b.BookingID DESC,
                    c.CustomerID DESC", conn);
            cmd.Parameters.AddWithValue("@phone", phone.Trim());

            using SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            return new CustomerBookingLookup
            {
                Customer = new Customer
                {
                    CustomerID = reader["CustomerID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CustomerID"]),
                    FullName = reader["FullName"]?.ToString() ?? string.Empty,
                    Gender = reader["Gender"]?.ToString() ?? string.Empty,
                    Phone = reader["Phone"]?.ToString() ?? string.Empty,
                    Email = reader["Email"]?.ToString() ?? string.Empty,
                    Address = reader["Address"]?.ToString() ?? string.Empty,
                    IDCardNumber = reader["IDCardNumber"]?.ToString() ?? string.Empty
                },
                BookingID = reader["BookingID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["BookingID"]),
                RoomID = reader["RoomID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RoomID"]),
                RoomType = reader["RoomType"]?.ToString() ?? string.Empty,
                RoomNumber = reader["RoomNumber"]?.ToString() ?? string.Empty,
                PricePerNight = reader["PricePerNight"] == DBNull.Value ? 0M : Convert.ToDecimal(reader["PricePerNight"]),
                TotalPrice = reader["TotalPrice"] == DBNull.Value ? 0M : Convert.ToDecimal(reader["TotalPrice"]),
                Deposit = reader["Deposit"] == DBNull.Value ? 0M : Convert.ToDecimal(reader["Deposit"]),
                CheckInDate = reader["CheckInDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["CheckInDate"]),
                CheckOutDate = reader["CheckOutDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["CheckOutDate"]),
                BookingStatus = reader["BookingStatus"]?.ToString() ?? string.Empty
            };
        }

        public bool Update(Customer customer)
        {
            string query = "UPDATE customers SET FullName=@name, Gender=@gender, Phone=@phone, " +
                           "Email=@email, Address=@address, IDCardNumber=@idcard WHERE CustomerID=@id";

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
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
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
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

            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

              
                if (fromDate.HasValue)
                {
                    query += " AND CAST(c.CreatedAt AS date) >= @FromDate";
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Value.Date);
                }

                if (toDate.HasValue)
                {
                    query += " AND CAST(c.CreatedAt AS date) <= @ToDate";
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
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        public DataTable GetAllRoomTypes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT RoomTypeID, TypeName FROM roomtypes ORDER BY TypeName";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

