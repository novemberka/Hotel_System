using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Models
{
    public class CheckIn
    {
        public int CheckInID { get; set; }
        public int BookingID { get; set; }

        // Add these two:
        public int CustomerID { get; set; }
        public int RoomID { get; set; }

        public DateTime CheckInDate { get; set; }
        public int CreatedByAdminID { get; set; }
    }
    public class CheckOut
    {
        public int CheckOutID { get; set; }
        public int CheckInID { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CreatedByAdminID { get; set; }
    }
}
