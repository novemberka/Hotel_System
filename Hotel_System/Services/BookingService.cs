using Hotel_System.Models;
using Hotel_System.Repositories;
using System;
using System.Data;

namespace Hotel_System.Services
{
    internal class BookingService
    {
        private readonly BookingRepository _repo = new BookingRepository();

        public DataTable GetBookingReport(DateTime fromDate, DateTime toDate,
                                          string roomType = "", string customerName = "")
            => _repo.GetBookingReport(fromDate, toDate, roomType, customerName);

        public DataTable GetBookingList()           => _repo.GetBookingList();
        public DataTable GetCustomerList()          => _repo.GetCustomerList();
        public DataTable GetAvailableRoomList()     => _repo.GetAvailableRoomList();
        public bool CreateBooking(Booking b)        => _repo.CreateBooking(b);
        public bool UpdateBooking(Booking b)        => _repo.UpdateBooking(b);
        public bool CancelBooking(int bid, int rid) => _repo.CancelBooking(bid, rid);
    }
}
