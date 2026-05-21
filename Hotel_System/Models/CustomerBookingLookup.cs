namespace Hotel_System.Models
{
    internal sealed class CustomerBookingLookup
    {
        public Customer Customer { get; init; } = new();
        public int BookingID { get; init; }
        public int RoomID { get; init; }
        public string RoomType { get; init; } = string.Empty;
        public string RoomNumber { get; init; } = string.Empty;
        public decimal PricePerNight { get; init; }
        public decimal TotalPrice { get; init; }
        public decimal Deposit { get; init; }
        public DateTime? CheckInDate { get; init; }
        public DateTime? CheckOutDate { get; init; }
        public string BookingStatus { get; init; } = string.Empty;
    }
}
