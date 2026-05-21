namespace Hotel_System.Models
{
    internal class Booking
    {
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public DateTime CheckInDate { get; set; } = DateTime.Today;
        public DateTime CheckOutDate { get; set; } = DateTime.Today.AddDays(1);
        public int Nights { get; set; } = 1;
        public string Status { get; set; } = "Reserved";
        public decimal PricePerNight { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Deposit { get; set; }
        public string Note { get; set; } = string.Empty;
        public int Adults { get; set; } = 1;
        public int Children { get; set; }
        public int? CreatedByAdminID { get; set; }
    }
}
