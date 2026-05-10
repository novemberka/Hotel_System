using Hotel_System.Models;
using Hotel_System.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Services
{
    internal class RoomService
    {
        private readonly RoomRepository _repo = new RoomRepository();

        public DataTable GetRooms() => _repo.GetRoomsFromDb();
        public DataTable SearchRooms(string roomNumber, string roomId, string status)
        {
            return _repo.Search(roomNumber, roomId, status);
        }
        public bool AddRoom(Room room) => _repo.Add(room);
        public bool UpdateRoom(Room room) => _repo.Update(room);
        public bool DeleteRoom(int id) => _repo.Delete(id);

        public DataTable GetRoomTypeList()
        {
            return _repo.GetRoomTypes();
        }
    }
}
    

