namespace Hotel_System.Models
{
    internal class Room
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public int Floor { get; set; }
        public string BedType { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public string Status { get; set; } = "Available";
    }
}
