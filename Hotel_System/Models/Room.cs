using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Models
{
    // Models/Room.cs
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public int RoomTypeID { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class RoomType
    {
        public int RoomTypeID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Floor { get; set; } = string.Empty;
    }
}
