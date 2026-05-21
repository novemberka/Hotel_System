using Hotel_System.Repositories;
using Hotel_System.Models;
using System.Data;

namespace Hotel_System.Services
{
    internal class PaymentService
    {
        private readonly PaymentRepository repository = new();

        public bool SavePayment(string customerName, string roomNumber, decimal amountPaid, decimal roomCharge, decimal serviceCharge, string paymentMethod)
        {
            if (string.IsNullOrWhiteSpace(customerName) && string.IsNullOrWhiteSpace(roomNumber))
            {
                throw new InvalidOperationException("Please enter a customer name or room number.");
            }

            if (amountPaid <= 0)
            {
                throw new InvalidOperationException("Amount paid must be greater than zero.");
            }

            return repository.SaveLatestCheckoutPayment(customerName, roomNumber, amountPaid, roomCharge, serviceCharge, paymentMethod);
        }

        public PaymentLookup? FindLatestCheckedOutStayByPhone(string phone)
        {
            return string.IsNullOrWhiteSpace(phone)
                ? null
                : repository.FindLatestCheckedOutStayByPhone(phone);
        }

        public DataTable GetPaymentReport()
        {
            return repository.GetPaymentReport();
        }
    }
}
