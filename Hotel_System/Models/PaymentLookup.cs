namespace Hotel_System.Models
{
    internal sealed class PaymentLookup
    {
        public string CustomerName { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public string RoomType { get; init; } = string.Empty;
        public string RoomNumber { get; init; } = string.Empty;
        public DateTime? CheckInDate { get; init; }
        public DateTime? CheckOutDate { get; init; }
        public bool HasCheckout { get; init; }
        public bool HasPayment { get; init; }
        public string PaymentStatus { get; init; } = string.Empty;
        public decimal RoomCharge { get; init; }
        public decimal ServiceCharge { get; init; }
        public decimal Discount { get; init; }
        public decimal Tax { get; init; }
        public decimal TotalAmount { get; init; }
        public decimal Remaining { get; init; }
    }
}
