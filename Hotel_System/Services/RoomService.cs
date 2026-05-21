using Hotel_System.Models;
using Hotel_System.Repositories;
using System.Data;

namespace Hotel_System.Services
{
    internal class RoomService
    {
        private readonly RoomRepository repository = new();

        public DataTable GetRooms(string? searchText = null)
        {
            return repository.GetAll(searchText);
        }

        public DataTable GetRoomTypes()
        {
            return repository.GetRoomTypes();
        }

        public DataTable GetAvailableRooms(string? roomType = null, string? bedType = null, int? minimumCapacity = null, decimal? maximumPrice = null)
        {
            return repository.GetAvailableRooms(roomType, bedType, minimumCapacity, maximumPrice);
        }

        public int GetNextRoomId()
        {
            return repository.GetNextRoomId();
        }

        public bool AddRoom(Room room)
        {
            Validate(room, requireId: false);
            return repository.Save(room);
        }

        public bool UpdateRoom(Room room)
        {
            Validate(room, requireId: true);
            return repository.Update(room);
        }

        public bool DeleteRoom(int roomId)
        {
            if (roomId <= 0)
            {
                throw new InvalidOperationException("Please select a room first.");
            }

            return repository.Delete(roomId);
        }

        private static void Validate(Room room, bool requireId)
        {
            if (requireId && room.RoomID <= 0)
            {
                throw new InvalidOperationException("Please select a room first.");
            }

            if (string.IsNullOrWhiteSpace(room.RoomNumber))
            {
                throw new InvalidOperationException("Room number cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(room.RoomType))
            {
                throw new InvalidOperationException("Please select a room type.");
            }

            if (room.Floor < 0)
            {
                throw new InvalidOperationException("Floor cannot be negative.");
            }

            if (string.IsNullOrWhiteSpace(room.BedType))
            {
                throw new InvalidOperationException("Bed type cannot be empty.");
            }

            if (room.Capacity <= 0)
            {
                throw new InvalidOperationException("Capacity must be greater than zero.");
            }

            if (room.PricePerNight < 0)
            {
                throw new InvalidOperationException("Price per night cannot be negative.");
            }
        }
    }
}
