using Hotel_System.Properties.Config;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotel_System.Services
{
    internal class CheckInService
    {
        private readonly DbConnection db = new DbConnection();

        public DataTable GetFrontDeskBookings(string? searchText = null)
        {
            DataTable table = new();
            using SqlConnection connection = db.GetConnection();
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                SELECT
                    b.BookingID,
                    c.FullName AS customer_name,
                    c.Phone AS phone_number,
                    r.RoomNumber AS room,
                    b.CheckInDate AS check_in,
                    b.CheckOutDate AS check_out,
                    b.TotalPrice AS total_price,
                    COALESCE(p.PaymentMethod, '') AS payment,
                    b.Status AS status
                FROM bookings b
                INNER JOIN customers c ON c.CustomerID = b.CustomerID
                INNER JOIN rooms r ON r.RoomID = b.RoomID
                LEFT JOIN checkins ci ON ci.BookingID = b.BookingID
                LEFT JOIN checkouts co ON co.CheckInID = ci.CheckInID
                LEFT JOIN payments p ON p.CheckOutID = co.CheckOutID
                WHERE @SearchText = ''
                   OR c.FullName LIKE CONCAT('%', @SearchText, '%')
                   OR c.Phone LIKE CONCAT('%', @SearchText, '%')
                   OR r.RoomNumber LIKE CONCAT('%', @SearchText, '%')
                   OR b.Status LIKE CONCAT('%', @SearchText, '%')
                ORDER BY b.BookingID DESC";
            command.Parameters.AddWithValue("@SearchText", searchText?.Trim() ?? string.Empty);

            using SqlDataAdapter adapter = new(command);
            adapter.Fill(table);
            return table;
        }

        public bool CheckIn(int bookingId)
        {
            if (bookingId <= 0)
            {
                throw new InvalidOperationException("Please load or select a booking first.");
            }

            using SqlConnection connection = db.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                string status = GetBookingStatus(connection, transaction, bookingId);
                if (status.Equals("Checked Out", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("This booking already checked out.");
                }

                if (status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) ||
                    status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("This booking is closed and cannot be checked in.");
                }

                BookingKeys keys = GetBookingKeys(connection, transaction, bookingId);
                int checkInId = GetCheckInId(connection, transaction, bookingId);

                if (checkInId <= 0)
                {
                    using SqlCommand insert = connection.CreateCommand();
                    insert.Transaction = transaction;
                    insert.CommandText = @"
                        INSERT INTO checkins (BookingID, CustomerID, RoomID, CheckInDate)
                        VALUES (@BookingID, @CustomerID, @RoomID, @CheckInDate)";
                    insert.Parameters.AddWithValue("@BookingID", bookingId);
                    insert.Parameters.AddWithValue("@CustomerID", keys.CustomerID);
                    insert.Parameters.AddWithValue("@RoomID", keys.RoomID);
                    insert.Parameters.AddWithValue("@CheckInDate", DateTime.Now);
                    insert.ExecuteNonQuery();
                }

                SetBookingStatus(connection, transaction, bookingId, "Checked In");
                SetRoomStatus(connection, transaction, keys.RoomID, "Occupied");
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool CheckOut(int bookingId, decimal subTotal, decimal discount, decimal total, decimal deposit, string paymentMethod)
        {
            if (bookingId <= 0)
            {
                throw new InvalidOperationException("Please load or select a booking first.");
            }

            using SqlConnection connection = db.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                string status = GetBookingStatus(connection, transaction, bookingId);
                if (status.Equals("Checked Out", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("This booking has already checked out.");
                }

                if (!status.Equals("Checked In", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("This customer has not checked in yet. Please check in before checkout.");
                }

                BookingKeys keys = GetBookingKeys(connection, transaction, bookingId);
                int checkInId = GetCheckInId(connection, transaction, bookingId);
                if (checkInId <= 0)
                {
                    throw new InvalidOperationException("This customer has no check-in record. Please check in before checkout.");
                }

                decimal remaining = Math.Max(0M, total - deposit);
                int checkOutId = GetCheckOutId(connection, transaction, checkInId);

                if (checkOutId <= 0)
                {
                    using SqlCommand insert = connection.CreateCommand();
                    insert.Transaction = transaction;
                    insert.CommandText = @"
                        INSERT INTO checkouts (CheckInID, CheckOutDate, SubTotal, Discount, Tax, TotalAmount, Deposit, Remaining)
                        VALUES (@CheckInID, @CheckOutDate, @SubTotal, @Discount, 0.00, @TotalAmount, @Deposit, @Remaining);
                        SELECT CAST(SCOPE_IDENTITY() AS int);";
                    AddCheckoutParameters(insert, checkInId, subTotal, discount, total, deposit, remaining);
                    checkOutId = Convert.ToInt32(insert.ExecuteScalar());
                }
                else
                {
                    using SqlCommand update = connection.CreateCommand();
                    update.Transaction = transaction;
                    update.CommandText = @"
                        UPDATE checkouts
                        SET CheckOutDate = @CheckOutDate,
                            SubTotal = @SubTotal,
                            Discount = @Discount,
                            TotalAmount = @TotalAmount,
                            Deposit = @Deposit,
                            Remaining = @Remaining
                        WHERE CheckOutID = @CheckOutID";
                    update.Parameters.AddWithValue("@CheckOutID", checkOutId);
                    AddCheckoutParameters(update, checkInId, subTotal, discount, total, deposit, remaining);
                    update.ExecuteNonQuery();
                }

                SetBookingStatus(connection, transaction, bookingId, "Checked Out");
                SetRoomStatus(connection, transaction, keys.RoomID, "Available");
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool UpdateBookingAmounts(int bookingId, DateTime checkInDate, DateTime checkOutDate, decimal total, decimal deposit)
        {
            if (bookingId <= 0)
            {
                throw new InvalidOperationException("Please load or select a booking first.");
            }

            using SqlConnection connection = db.GetConnection();
            connection.Open();
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE bookings
                SET CheckInDate = @CheckInDate,
                    CheckOutDate = @CheckOutDate,
                    TotalPrice = @TotalPrice,
                    Deposit = @Deposit
                WHERE BookingID = @BookingID";
            command.Parameters.AddWithValue("@BookingID", bookingId);
            command.Parameters.AddWithValue("@CheckInDate", checkInDate);
            command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
            command.Parameters.AddWithValue("@TotalPrice", total);
            command.Parameters.AddWithValue("@Deposit", deposit);
            return command.ExecuteNonQuery() > 0;
        }

        private static void AddCheckoutParameters(SqlCommand command, int checkInId, decimal subTotal, decimal discount, decimal total, decimal deposit, decimal remaining)
        {
            command.Parameters.AddWithValue("@CheckInID", checkInId);
            command.Parameters.AddWithValue("@CheckOutDate", DateTime.Now);
            command.Parameters.AddWithValue("@SubTotal", subTotal);
            command.Parameters.AddWithValue("@Discount", discount);
            command.Parameters.AddWithValue("@TotalAmount", total);
            command.Parameters.AddWithValue("@Deposit", deposit);
            command.Parameters.AddWithValue("@Remaining", remaining);
        }

        private static BookingKeys GetBookingKeys(SqlConnection connection, SqlTransaction transaction, int bookingId)
        {
            using SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "SELECT TOP 1 CustomerID, RoomID FROM bookings WHERE BookingID = @BookingID";
            command.Parameters.AddWithValue("@BookingID", bookingId);

            using SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                throw new InvalidOperationException("Booking was not found.");
            }

            return new BookingKeys(Convert.ToInt32(reader["CustomerID"]), Convert.ToInt32(reader["RoomID"]));
        }

        private static string GetBookingStatus(SqlConnection connection, SqlTransaction transaction, int bookingId)
        {
            using SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "SELECT TOP 1 Status FROM bookings WHERE BookingID = @BookingID";
            command.Parameters.AddWithValue("@BookingID", bookingId);
            object? value = command.ExecuteScalar();

            if (value == null || value == DBNull.Value)
            {
                throw new InvalidOperationException("Booking was not found.");
            }

            return Convert.ToString(value) ?? string.Empty;
        }

        private static int GetCheckInId(SqlConnection connection, SqlTransaction transaction, int bookingId)
        {
            using SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "SELECT TOP 1 CheckInID FROM checkins WHERE BookingID = @BookingID ORDER BY CheckInID DESC";
            command.Parameters.AddWithValue("@BookingID", bookingId);
            object? value = command.ExecuteScalar();
            return value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);
        }

        private static int GetCheckOutId(SqlConnection connection, SqlTransaction transaction, int checkInId)
        {
            using SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "SELECT TOP 1 CheckOutID FROM checkouts WHERE CheckInID = @CheckInID";
            command.Parameters.AddWithValue("@CheckInID", checkInId);
            object? value = command.ExecuteScalar();
            return value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);
        }

        private static void SetBookingStatus(SqlConnection connection, SqlTransaction transaction, int bookingId, string status)
        {
            using SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "UPDATE bookings SET Status = @Status WHERE BookingID = @BookingID";
            command.Parameters.AddWithValue("@BookingID", bookingId);
            command.Parameters.AddWithValue("@Status", status);
            command.ExecuteNonQuery();
        }

        private static void SetRoomStatus(SqlConnection connection, SqlTransaction transaction, int roomId, string status)
        {
            using SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "UPDATE rooms SET Status = @Status WHERE RoomID = @RoomID";
            command.Parameters.AddWithValue("@RoomID", roomId);
            command.Parameters.AddWithValue("@Status", status);
            command.ExecuteNonQuery();
        }

        private readonly record struct BookingKeys(int CustomerID, int RoomID);
    }
}

