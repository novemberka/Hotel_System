using Hotel_System.Repositories;
using System;
using System.Data;

namespace Hotel_System.Services
{
    internal class PaymentService
    {
        private readonly PaymentRepository _repo = new PaymentRepository();

        public DataTable GetPaymentReport(DateTime fromDate, DateTime toDate, string roomType = "")
            => _repo.GetPaymentReport(fromDate, toDate, roomType);
    }
}
