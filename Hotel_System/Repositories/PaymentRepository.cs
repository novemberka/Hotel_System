using Hotel_System.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hotel_System.Repositories
{
    internal class PaymentRepository
    {
        private readonly string connectionString =
            "server=localhost;database=hoteldb;uid=root;pwd=;";

        
        public bool AddPayment(Payment payment)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"INSERT INTO payments
                                (BookingID, PaymentDate, PaymentType,
                                 TotalAmount, CheckInDate, CheckOutDate)
                                 VALUES
                                (@BookingID,@PaymentDate,@PaymentType,
                                 @TotalAmount,@CheckInDate,@CheckOutDate)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@BookingID", payment.BookingID);
                cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                cmd.Parameters.AddWithValue("@PaymentType", payment.PaymentType);
                cmd.Parameters.AddWithValue("@TotalAmount", payment.TotalAmount);
                cmd.Parameters.AddWithValue("@CheckInDate", payment.CheckInDate);
                cmd.Parameters.AddWithValue("@CheckOutDate", payment.CheckOutDate);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

       
        public DataTable GetPayments()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT 
                                BookingID,
                                PaymentType,
                                TotalAmount,
                                CheckInDate,
                                CheckOutDate
                                FROM payments";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

                DataTable table = new DataTable();

                adapter.Fill(table);

                return table;
            }
        }
    }
}