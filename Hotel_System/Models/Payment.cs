namespace Hotel_System.Models
{
    internal class Payment
    {
        public int PaymentID { get; set; }
        public int CheckOutID { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal AmountPaid { get; set; }
        public string PaymentMethod { get; set; } = "Cash";
        public string PaymentStatus { get; set; } = "Paid";
    }
}
