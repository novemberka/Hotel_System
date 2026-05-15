using Hotel_System.Models;
using Hotel_System.Repositories;
using System.Data;

namespace Hotel_System.Services
{
    internal class PaymentService
    {
        private PaymentRepository repository =
            new PaymentRepository();

        public bool AddPayment(Payment payment)
        {
            return repository.AddPayment(payment);
        }

        public DataTable GetPayments()
        {
            return repository.GetPayments();
        }
    }
}