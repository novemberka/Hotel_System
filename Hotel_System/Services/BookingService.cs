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

        public DataTable GetBookingList()       => _repo.GetBookingList();
        public DataTable GetCustomerList()      => _repo.GetCustomerList();
        public DataTable GetAvailableRoomList() => _repo.GetAvailableRoomList();

        public bool CreateBooking(Booking booking)
        {
            if (booking.CheckInDate.Date >= booking.CheckOutDate.Date)
                throw new Exception("Check-out must be after Check-in.");
            return _repo.Add(booking);
        }

        public bool UpdateBooking(Booking booking)
        {
            if (booking.BookingID <= 0)
                throw new Exception("Invalid Booking ID.");

            if (booking.CheckInDate.Date >= booking.CheckOutDate.Date)
                throw new Exception("Invalid date range: Check-out must be after Check-in.");

            string currentStatus = _repo.GetBookingStatus(booking.BookingID);

            if (currentStatus == "Cancelled")
                throw new Exception("This booking is Cancelled and cannot be modified.");

            if (currentStatus == "Complete")
                throw new Exception("Cannot update a completed booking.");

            return _repo.UpdateBooking(booking);
        }

        public bool CancelBooking(int bID, int rID)
        {
            return _repo.UpdateStatusAndReleaseRoom(bID, rID, "Cancelled");
        }
    }
}
