using System;
using System.Data;
using Hotel_System.Models;
using Hotel_System.Repositories;

namespace Hotel_System.Services
{
    internal class BookingService
    {
        private readonly BookingRepository _repo = new BookingRepository();

        public DataTable GetBookingList() => _repo.GetBookingsFromDb();
        public DataTable GetCustomerList() => _repo.GetCustomersForBooking();
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

            // Validation: Prevent logical date errors
            if (booking.CheckInDate.Date >= booking.CheckOutDate.Date)
                throw new Exception("Invalid date range: Check-out must be after Check-in.");
            string currentStatus = _repo.GetBookingStatus(booking.BookingID);

            if (currentStatus == "Cancelled")
            {
                throw new Exception("This booking is Cancelled and cannot be modified.");
            }

            if (currentStatus == "Complete")
            {
                throw new Exception("Cannot update a completed booking.");
            }

            return _repo.UpdateBooking(booking);
        }
        public bool ProcessCheckIn(int bID) => _repo.ConfirmCheckIn(bID);

        // Inside BookingService.cs

        public bool CompleteCheckOut(int bID, int rID)
        {
            return _repo.UpdateStatusAndReleaseRoom(bID, rID, "Complete");
        }

        public bool CancelBooking(int bID, int rID)
        {
            return _repo.UpdateStatusAndReleaseRoom(bID, rID, "Cancelled");
        }
    }
}