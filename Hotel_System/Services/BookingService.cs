using Hotel_System.Repositories;
using System;
using System.Data;

namespace Hotel_System.Services
{
    internal class BookingService
    {
        private readonly BookingRepository _repo = new BookingRepository();

        public DataTable GetBookingReport(DateTime fromDate, DateTime toDate)
        {
            return _repo.GetBookingReport(fromDate, toDate);
        }
    }
}
