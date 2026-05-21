using Hotel_System.Properties.Config;
using Hotel_System.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotel_System.Repositories
{
    internal class PaymentRepository
    {
        private readonly DbConnection db = new DbConnection();

        public bool SaveLatestCheckoutPayment(string customerName, string roomNumber, decimal amountPaid, decimal roomCharge, decimal serviceCharge, string paymentMethod)
        {
            using SqlConnection connection = db.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                int checkOutId = FindLatestCheckOutId(connection, transaction, customerName, roomNumber);
                decimal totalAmount = GetCheckoutTotal(connection, transaction, checkOutId);
                decimal remaining = Math.Max(0M, totalAmount - amountPaid);
                string status = remaining <= 0 ? "Paid" : amountPaid > 0 ? "Partial" : "Pending";

                using SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = @"
                    INSERT INTO payments
                        (CheckOutID, AmountPaid, RoomCharge, ServiceCharge, PaymentMethod, PaymentStatus)
                    VALUES
                        (@CheckOutID, @AmountPaid, @RoomCharge, @ServiceCharge, @PaymentMethod, @PaymentStatus)";
                command.Parameters.AddWithValue("@CheckOutID", checkOutId);
                command.Parameters.AddWithValue("@AmountPaid", amountPaid);
                command.Parameters.AddWithValue("@RoomCharge", roomCharge);
                command.Parameters.AddWithValue("@ServiceCharge", serviceCharge);
                command.Parameters.AddWithValue("@PaymentMethod", string.IsNullOrWhiteSpace(paymentMethod) ? "Cash" : paymentMethod);
                command.Parameters.AddWithValue("@PaymentStatus", status);
                bool saved = command.ExecuteNonQuery() > 0;

                using SqlCommand updateCheckout = connection.CreateCommand();
                updateCheckout.Transaction = transaction;
                updateCheckout.CommandText = "UPDATE checkouts SET Remaining = @Remaining WHERE CheckOutID = @CheckOutID";
                updateCheckout.Parameters.AddWithValue("@CheckOutID", checkOutId);
                updateCheckout.Parameters.AddWithValue("@Remaining", remaining);
                updateCheckout.ExecuteNonQuery();

                transaction.Commit();
                return saved;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public PaymentLookup? FindLatestCheckedOutStayByPhone(string phone)
        {
            using SqlConnection connection = db.GetConnection();
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                SELECT
                    c.FullName,
                    c.Phone,
                    rt.TypeName AS RoomType,
                    r.RoomNumber,
                    COALESCE(ci.CheckInDate, b.CheckInDate) AS CheckInDate,
                    COALESCE(co.CheckOutDate, b.CheckOutDate) AS CheckOutDate,
                    co.CheckOutID,
                    p.PaymentID,
                    COALESCE(p.PaymentStatus, '') AS PaymentStatus,
                    COALESCE(co.SubTotal, b.PricePerNight * CASE WHEN b.Nights > 1 THEN b.Nights ELSE 1 END, b.TotalPrice, 0.00) AS SubTotal,
                    COALESCE(co.Discount, b.Discount, 0.00) AS Discount,
                    COALESCE(co.Tax, 0.00) AS Tax,
                    COALESCE(co.TotalAmount, b.TotalPrice, 0.00) AS TotalAmount,
                    CASE
                        WHEN co.CheckOutID IS NULL THEN COALESCE(b.TotalPrice, 0.00)
                        WHEN p.PaymentID IS NULL THEN COALESCE(co.TotalAmount, b.TotalPrice, 0.00)
                        WHEN co.Remaining IS NULL THEN COALESCE(co.TotalAmount, b.TotalPrice, 0.00)
                        ELSE co.Remaining
                    END AS Remaining
                FROM customers c
                LEFT JOIN bookings b ON b.CustomerID = c.CustomerID
                LEFT JOIN rooms r ON r.RoomID = b.RoomID
                LEFT JOIN roomtypes rt ON rt.RoomTypeID = r.RoomTypeID
                LEFT JOIN checkins ci ON ci.BookingID = b.BookingID
                LEFT JOIN checkouts co ON co.CheckInID = ci.CheckInID
                LEFT JOIN (
                    SELECT latest.CheckOutID, p.PaymentID, p.PaymentStatus
                    FROM payments p
                    INNER JOIN (
                        SELECT CheckOutID, MAX(PaymentID) AS PaymentID
                        FROM payments
                        GROUP BY CheckOutID
                    ) latest ON latest.PaymentID = p.PaymentID
                ) p ON p.CheckOutID = co.CheckOutID
                WHERE c.Phone = @Phone
                ORDER BY
                    CASE
                        WHEN b.Status = 'Checked Out' THEN 0
                        WHEN b.Status = 'Checked In' THEN 1
                        WHEN b.Status = 'Reserved' THEN 2
                        WHEN b.Status = 'Booked' THEN 3
                        WHEN b.Status = 'Completed' THEN 4
                        WHEN b.Status = 'Cancelled' THEN 5
                        ELSE 6
                    END,
                    co.CheckOutDate DESC,
                    b.BookingID DESC,
                    c.CustomerID DESC
                OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY";
            command.Parameters.AddWithValue("@Phone", phone.Trim());

            using SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            return new PaymentLookup
            {
                CustomerName = reader["FullName"]?.ToString() ?? string.Empty,
                Phone = reader["Phone"]?.ToString() ?? string.Empty,
                RoomType = reader["RoomType"]?.ToString() ?? string.Empty,
                RoomNumber = reader["RoomNumber"]?.ToString() ?? string.Empty,
                CheckInDate = reader["CheckInDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["CheckInDate"]),
                CheckOutDate = reader["CheckOutDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["CheckOutDate"]),
                HasCheckout = reader["CheckOutID"] != DBNull.Value,
                HasPayment = reader["PaymentID"] != DBNull.Value,
                PaymentStatus = reader["PaymentStatus"]?.ToString() ?? string.Empty,
                RoomCharge = reader["SubTotal"] == DBNull.Value ? 0M : Convert.ToDecimal(reader["SubTotal"]),
                ServiceCharge = 0M,
                Discount = reader["Discount"] == DBNull.Value ? 0M : Convert.ToDecimal(reader["Discount"]),
                Tax = reader["Tax"] == DBNull.Value ? 0M : Convert.ToDecimal(reader["Tax"]),
                TotalAmount = reader["TotalAmount"] == DBNull.Value ? 0M : Convert.ToDecimal(reader["TotalAmount"]),
                Remaining = reader["Remaining"] == DBNull.Value ? 0M : Convert.ToDecimal(reader["Remaining"])
            };
        }

        public DataTable GetPaymentReport()
        {
            DataTable table = new();
            using SqlConnection connection = db.GetConnection();
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                SELECT
                    p.PaymentID,
                    c.FullName AS CustomerName,
                    c.Phone AS PhoneNumber,
                    r.RoomNumber,
                    rt.TypeName AS RoomType,
                    ci.CheckInDate,
                    co.CheckOutDate,
                    p.PaymentDate,
                    p.RoomCharge,
                    p.ServiceCharge,
                    p.AmountPaid,
                    p.PaymentMethod,
                    p.PaymentStatus
                FROM payments p
                INNER JOIN checkouts co ON co.CheckOutID = p.CheckOutID
                INNER JOIN checkins ci ON ci.CheckInID = co.CheckInID
                INNER JOIN customers c ON c.CustomerID = ci.CustomerID
                INNER JOIN rooms r ON r.RoomID = ci.RoomID
                INNER JOIN roomtypes rt ON rt.RoomTypeID = r.RoomTypeID
                ORDER BY p.PaymentID DESC";

            using SqlDataAdapter adapter = new(command);
            adapter.Fill(table);
            return table;
        }

        private static int FindLatestCheckOutId(SqlConnection connection, SqlTransaction transaction, string customerName, string roomNumber)
        {
            using SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = @"
                SELECT TOP 1 co.CheckOutID
                FROM checkouts co
                INNER JOIN checkins ci ON ci.CheckInID = co.CheckInID
                INNER JOIN bookings b ON b.BookingID = ci.BookingID
                INNER JOIN customers c ON c.CustomerID = ci.CustomerID
                INNER JOIN rooms r ON r.RoomID = ci.RoomID
                WHERE (@CustomerName = '' OR c.FullName LIKE CONCAT('%', @CustomerName, '%'))
                  AND (@RoomNumber = '' OR r.RoomNumber = @RoomNumber)
                  AND b.Status = 'Checked Out'
                ORDER BY co.CheckOutID DESC";
            command.Parameters.AddWithValue("@CustomerName", customerName.Trim());
            command.Parameters.AddWithValue("@RoomNumber", roomNumber.Trim());
            object? value = command.ExecuteScalar();

            if (value == null || value == DBNull.Value)
            {
                throw new InvalidOperationException("Payment is only allowed after checkout. Please complete checkout first.");
            }

            return Convert.ToInt32(value);
        }

        private static decimal GetCheckoutTotal(SqlConnection connection, SqlTransaction transaction, int checkOutId)
        {
            using SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "SELECT TotalAmount FROM checkouts WHERE CheckOutID = @CheckOutID";
            command.Parameters.AddWithValue("@CheckOutID", checkOutId);
            object? value = command.ExecuteScalar();
            return value == null || value == DBNull.Value ? 0M : Convert.ToDecimal(value);
        }
    }
}

