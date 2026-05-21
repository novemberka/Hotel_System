using Hotel_System.Models;
using Hotel_System.Properties.Config;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotel_System.Repositories
{
    internal class RoomRepository
    {
        private readonly DbConnection db = new DbConnection();

        public DataTable GetAll(string? searchText = null)
        {
            DataTable table = new();
            using SqlConnection connection = db.GetConnection();
            using SqlCommand command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    r.RoomID,
                    r.RoomNumber,
                    rt.TypeName AS RoomType,
                    r.Floor,
                    r.BedType,
                    r.Capacity,
                    r.PricePerNight,
                    r.Status
                FROM rooms r
                INNER JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID
                WHERE @SearchText = ''
                   OR r.RoomNumber LIKE CONCAT('%', @SearchText, '%')
                   OR rt.TypeName LIKE CONCAT('%', @SearchText, '%')
                   OR r.Status LIKE CONCAT('%', @SearchText, '%')
                ORDER BY r.RoomNumber";
            command.Parameters.AddWithValue("@SearchText", searchText?.Trim() ?? string.Empty);

            using SqlDataAdapter adapter = new(command);
            adapter.Fill(table);
            return table;
        }

        public DataTable GetRoomTypes()
        {
            DataTable table = new();
            using SqlConnection connection = db.GetConnection();
            using SqlDataAdapter adapter = new(
                "SELECT RoomTypeID, TypeName, PricePerNight, Capacity FROM roomtypes ORDER BY TypeName",
                connection);
            adapter.Fill(table);
            return table;
        }

        public DataTable GetAvailableRooms(string? roomType = null, string? bedType = null, int? minimumCapacity = null, decimal? maximumPrice = null)
        {
            DataTable table = new();
            using SqlConnection connection = db.GetConnection();
            using SqlCommand command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    r.RoomID,
                    r.RoomNumber,
                    rt.TypeName AS RoomType,
                    r.Floor,
                    r.BedType,
                    r.Capacity,
                    r.PricePerNight,
                    r.Status
                FROM rooms r
                INNER JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID
                WHERE r.Status = 'Available'
                  AND (@RoomType = '' OR rt.TypeName = @RoomType)
                  AND (@BedType = '' OR r.BedType LIKE CONCAT('%', @BedType, '%'))
                  AND (@MinimumCapacity = 0 OR r.Capacity >= @MinimumCapacity)
                  AND (@MaximumPrice = 0 OR r.PricePerNight <= @MaximumPrice)
                ORDER BY rt.TypeName, r.PricePerNight, r.RoomNumber";

            command.Parameters.AddWithValue("@RoomType", roomType?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@BedType", bedType?.Trim() ?? string.Empty);
            command.Parameters.AddWithValue("@MinimumCapacity", minimumCapacity.GetValueOrDefault());
            command.Parameters.AddWithValue("@MaximumPrice", maximumPrice.GetValueOrDefault());

            using SqlDataAdapter adapter = new(command);
            adapter.Fill(table);
            return table;
        }

        public int GetNextRoomId()
        {
            using SqlConnection connection = db.GetConnection();
            connection.Open();
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COALESCE(MAX(RoomID), 0) + 1 FROM rooms";
            object? value = command.ExecuteScalar();
            return value == null || value == DBNull.Value ? 1 : Convert.ToInt32(value);
        }

        public bool Save(Room room)
        {
            using SqlConnection connection = db.GetConnection();
            connection.Open();

            int roomTypeId = GetRoomTypeId(connection, room.RoomType);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO rooms (RoomNumber, RoomTypeID, Floor, BedType, Capacity, PricePerNight, Status)
                VALUES (@RoomNumber, @RoomTypeID, @Floor, @BedType, @Capacity, @PricePerNight, @Status)";
            AddRoomParameters(command, room, roomTypeId);
            return command.ExecuteNonQuery() > 0;
        }

        public bool Update(Room room)
        {
            using SqlConnection connection = db.GetConnection();
            connection.Open();

            int roomTypeId = GetRoomTypeId(connection, room.RoomType);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE rooms
                SET RoomNumber = @RoomNumber,
                    RoomTypeID = @RoomTypeID,
                    Floor = @Floor,
                    BedType = @BedType,
                    Capacity = @Capacity,
                    PricePerNight = @PricePerNight,
                    Status = @Status
                WHERE RoomID = @RoomID";
            command.Parameters.AddWithValue("@RoomID", room.RoomID);
            AddRoomParameters(command, room, roomTypeId);
            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(int roomId)
        {
            using SqlConnection connection = db.GetConnection();
            connection.Open();
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM rooms WHERE RoomID = @RoomID";
            command.Parameters.AddWithValue("@RoomID", roomId);
            return command.ExecuteNonQuery() > 0;
        }

        private static void AddRoomParameters(SqlCommand command, Room room, int roomTypeId)
        {
            command.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
            command.Parameters.AddWithValue("@RoomTypeID", roomTypeId);
            command.Parameters.AddWithValue("@Floor", room.Floor);
            command.Parameters.AddWithValue("@BedType", room.BedType);
            command.Parameters.AddWithValue("@Capacity", room.Capacity);
            command.Parameters.AddWithValue("@PricePerNight", room.PricePerNight);
            command.Parameters.AddWithValue("@Status", room.Status);
        }

        private static int GetRoomTypeId(SqlConnection connection, string roomType)
        {
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT TOP 1 RoomTypeID FROM roomtypes WHERE TypeName = @RoomType";
            command.Parameters.AddWithValue("@RoomType", roomType);

            object? value = command.ExecuteScalar();
            if (value == null || value == DBNull.Value)
            {
                throw new InvalidOperationException("Please select a valid room type.");
            }

            return Convert.ToInt32(value);
        }
    }
}

