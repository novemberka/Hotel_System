namespace Hotel_System.Models
{
    internal class Customer
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string IDCardNumber { get; set; } = string.Empty;
    }
}
