using Hotel_System.Repositories;
using System;
using System.Data;

namespace Hotel_System.Services
{
    internal class CheckoutService
    {
        private readonly CheckoutRepository _repo = new CheckoutRepository();

        public DataTable GetCheckOutReport(DateTime fromDate, DateTime toDate, string roomType = "")
            => _repo.GetCheckOutReport(fromDate, toDate, roomType);
    }
}
