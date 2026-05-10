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
        public string RoomNumber { get; set; }
        public int RoomTypeID { get; set; } // Foreign Key
        public string Status { get; set; }
    }

    // Models/RoomType.cs
    public class RoomType
    {
        public int RoomTypeID { get; set; }
        public string TypeName { get; set; } // e.g., "Deluxe"
        public decimal Price { get; set; }
    }
}
