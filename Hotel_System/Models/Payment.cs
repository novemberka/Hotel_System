using System;

namespace Hotel_System.Models
{
    internal class Payment
    {
        public int PaymentID { get; set; }

        public int BookingID { get; set; }

        public string RoomType { get; set; }

        public string RoomNumber { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentType { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }
    }
}