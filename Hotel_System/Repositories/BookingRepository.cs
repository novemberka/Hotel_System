using Hotel_System.Models;
using Hotel_System.Properties.Config;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotel_System.Repositories
{
    internal class BookingRepository
    {
        private readonly DbConnection db = new DbConnection();

        public int GetNextBookingId()
        {
            using SqlConnection connection = db.GetConnection();
            connection.Open();
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COALESCE(MAX(BookingID), 0) + 1 FROM bookings";
            object? value = command.ExecuteScalar();
            return value == null || value == DBNull.Value ? 1 : Convert.ToInt32(value);
        }

        public DataTable GetAll(string? searchText = null)
        {
            DataTable table = new();
            using SqlConnection connection = db.GetConnection();
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                SELECT
                    b.BookingID,
                    b.CustomerID,
                    b.RoomID,
                    c.FullName AS GuestName,
                    c.Phone AS PhoneNumber,
                    c.Email,
                    c.Address,
                    c.IDCardNumber,
                    r.RoomNumber AS Room,
                    rt.TypeName AS RoomType,
                    b.CheckInDate,
                    b.CheckOutDate,
                    b.Nights,
                    b.PricePerNight,
                    b.Discount,
                    b.Status,
                    b.TotalPrice,
                    b.Deposit,
                    b.Note
                FROM bookings b
                INNER JOIN customers c ON c.CustomerID = b.CustomerID
                INNER JOIN rooms r ON r.RoomID = b.RoomID
                INNER JOIN roomtypes rt ON rt.RoomTypeID = r.RoomTypeID
                WHERE @SearchText = ''
                   OR b.BookingID LIKE CONCAT('%', @SearchText, '%')
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

        public bool Save(Booking booking, Customer customer)
        {
            using SqlConnection connection = db.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                booking.CustomerID = SaveOrUpdateCustomer(connection, transaction, customer);

                using SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = @"
                    INSERT INTO bookings
                        (CustomerID, RoomID, CheckInDate, CheckOutDate, Nights, Adults, Children, Status, Note, PricePerNight, Discount, TotalPrice, Deposit, CreatedByAdminID)
                    VALUES
                        (@CustomerID, @RoomID, @CheckInDate, @CheckOutDate, @Nights, @Adults, @Children, @Status, @Note, @PricePerNight, @Discount, @TotalPrice, @Deposit, @CreatedByAdminID)";
                AddBookingParameters(command, booking);
                bool saved = command.ExecuteNonQuery() > 0;
                SetRoomStatus(connection, transaction, booking.RoomID, RoomStatusForBooking(booking.Status));

                transaction.Commit();
                return saved;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool Update(Booking booking, Customer customer)
        {
            using SqlConnection connection = db.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                int previousRoomId = GetBookingRoomId(connection, transaction, booking.BookingID);
                booking.CustomerID = SaveOrUpdateCustomer(connection, transaction, customer);

                using SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = @"
                    UPDATE bookings
                    SET CustomerID = @CustomerID,
                        RoomID = @RoomID,
                        CheckInDate = @CheckInDate,
                        CheckOutDate = @CheckOutDate,
                        Nights = @Nights,
                        Adults = @Adults,
                        Children = @Children,
                        Status = @Status,
                        Note = @Note,
                        PricePerNight = @PricePerNight,
                        Discount = @Discount,
                        TotalPrice = @TotalPrice,
                        Deposit = @Deposit,
                        CreatedByAdminID = @CreatedByAdminID
                    WHERE BookingID = @BookingID";
                command.Parameters.AddWithValue("@BookingID", booking.BookingID);
                AddBookingParameters(command, booking);
                bool updated = command.ExecuteNonQuery() > 0;

                if (previousRoomId > 0 && previousRoomId != booking.RoomID)
                {
                    SetRoomStatus(connection, transaction, previousRoomId, "Available");
                }

                SetRoomStatus(connection, transaction, booking.RoomID, RoomStatusForBooking(booking.Status));
                transaction.Commit();
                return updated;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool Cancel(int bookingId)
        {
            using SqlConnection connection = db.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                int roomId = GetBookingRoomId(connection, transaction, bookingId);
                using SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = "UPDATE bookings SET Status = 'Cancelled' WHERE BookingID = @BookingID";
                command.Parameters.AddWithValue("@BookingID", bookingId);
                bool cancelled = command.ExecuteNonQuery() > 0;

                if (roomId > 0)
                {
                    SetRoomStatus(connection, transaction, roomId, "Available");
                }

                transaction.Commit();
                return cancelled;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static void AddBookingParameters(SqlCommand command, Booking booking)
        {
            command.Parameters.AddWithValue("@CustomerID", booking.CustomerID);
            command.Parameters.AddWithValue("@RoomID", booking.RoomID);
            command.Parameters.AddWithValue("@CheckInDate", booking.CheckInDate);
            command.Parameters.AddWithValue("@CheckOutDate", booking.CheckOutDate);
            command.Parameters.AddWithValue("@Nights", Math.Max(1, booking.Nights));
            command.Parameters.AddWithValue("@Adults", Math.Max(1, booking.Adults));
            command.Parameters.AddWithValue("@Children", Math.Max(0, booking.Children));
            command.Parameters.AddWithValue("@Status", string.IsNullOrWhiteSpace(booking.Status) ? "Reserved" : booking.Status);
            command.Parameters.AddWithValue("@Note", string.IsNullOrWhiteSpace(booking.Note) ? DBNull.Value : booking.Note);
            command.Parameters.AddWithValue("@PricePerNight", booking.PricePerNight);
            command.Parameters.AddWithValue("@Discount", booking.Discount);
            command.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);
            command.Parameters.AddWithValue("@Deposit", booking.Deposit);
            command.Parameters.AddWithValue("@CreatedByAdminID", booking.CreatedByAdminID.HasValue ? booking.CreatedByAdminID.Value : DBNull.Value);
        }

        private static int SaveOrUpdateCustomer(SqlConnection connection, SqlTransaction transaction, Customer customer)
        {
            int existingId = FindCustomerIdByPhone(connection, transaction, customer.Phone);
            if (existingId > 0)
            {
                using SqlCommand update = connection.CreateCommand();
                update.Transaction = transaction;
                update.CommandText = @"
                    UPDATE customers
                    SET FullName = @FullName,
                        Email = @Email,
                        Address = @Address,
                        IDCardNumber = @IDCardNumber
                    WHERE CustomerID = @CustomerID";
                update.Parameters.AddWithValue("@CustomerID", existingId);
                AddCustomerParameters(update, customer);
                update.ExecuteNonQuery();
                return existingId;
            }

            using SqlCommand insert = connection.CreateCommand();
            insert.Transaction = transaction;
            insert.CommandText = @"
                INSERT INTO customers (FullName, Gender, Phone, Email, Address, IDCardNumber)
                VALUES (@FullName, @Gender, @Phone, @Email, @Address, @IDCardNumber);
                SELECT CAST(SCOPE_IDENTITY() AS int);";
            AddCustomerParameters(insert, customer);
            object? value = insert.ExecuteScalar();
            return Convert.ToInt32(value);
        }

        private static void AddCustomerParameters(SqlCommand command, Customer customer)
        {
            command.Parameters.AddWithValue("@FullName", customer.FullName.Trim());
            command.Parameters.AddWithValue("@Gender", string.IsNullOrWhiteSpace(customer.Gender) ? DBNull.Value : customer.Gender.Trim());
            command.Parameters.AddWithValue("@Phone", customer.Phone.Trim());
            command.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(customer.Email) ? DBNull.Value : customer.Email.Trim());
            command.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(customer.Address) ? DBNull.Value : customer.Address.Trim());
            command.Parameters.AddWithValue("@IDCardNumber", string.IsNullOrWhiteSpace(customer.IDCardNumber) ? DBNull.Value : customer.IDCardNumber.Trim());
        }

        private static int FindCustomerIdByPhone(SqlConnection connection, SqlTransaction transaction, string phone)
        {
            using SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "SELECT TOP 1 CustomerID FROM customers WHERE Phone = @Phone ORDER BY CustomerID DESC";
            command.Parameters.AddWithValue("@Phone", phone.Trim());
            object? value = command.ExecuteScalar();
            return value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);
        }

        private static int GetBookingRoomId(SqlConnection connection, SqlTransaction transaction, int bookingId)
        {
            using SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "SELECT TOP 1 RoomID FROM bookings WHERE BookingID = @BookingID";
            command.Parameters.AddWithValue("@BookingID", bookingId);
            object? value = command.ExecuteScalar();
            return value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);
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

        private static string RoomStatusForBooking(string bookingStatus)
        {
            return bookingStatus switch
            {
                "Cancelled" or "Completed" or "Checked Out" => "Available",
                "Checked In" => "Occupied",
                _ => "Reserved"
            };
        }
    }
}

