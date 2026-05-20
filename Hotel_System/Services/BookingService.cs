using Hotel_System.Models;
using Hotel_System.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Hotel_System.Services
{
    internal class BookingService
    {
        private readonly BookingRepository _repo =
            new BookingRepository();

        public bool CreateBooking(Booking booking)
        {
            if (booking.CheckInDate.Date >= booking.CheckOutDate.Date)
            {
                throw new Exception(
                    "Check-out must be after Check-in.");
            }

            return _repo.SaveBooking(booking);
        }

        public bool UpdateBooking(Booking booking)
        {
            if (booking.BookingID <= 0)
            {
                throw new Exception("Invalid Booking ID.");
            }

            if (booking.CheckInDate.Date >= booking.CheckOutDate.Date)
            {
                throw new Exception(
                    "Invalid date range: Check-out must be after Check-in.");
            }

            string currentStatus =
                _repo.GetBookingStatus(booking.BookingID);

            if (currentStatus == "Cancelled")
            {
                throw new Exception(
                    "This booking is Cancelled and cannot be modified.");
            }

            if (currentStatus == "Complete")
            {
                throw new Exception(
                    "Cannot update a completed booking.");
            }

            return _repo.UpdateBooking(booking);
        }

        public bool CancelBooking(int bookingID, int roomID)
        {
            return _repo.UpdateStatusAndReleaseRoom(
                bookingID,
                roomID,
                "Cancelled");
        }

        public DataTable GetBookingList()
        {
            return _repo.GetBookingsFromDb();
        }

        public DataTable GetCustomerList()
        {
            return _repo.GetCustomerList();
        }

        public DataTable GetAvailableRoomList()
        {
            return _repo.GetAvailableRoomList();
        }

        public DataTable GetBookingReport(
            DateTime fromDate,
            DateTime toDate,
            string roomType = "",
            string customerName = "")
        {
            return _repo.GetBookingReport(
                fromDate,
                toDate,
                roomType,
                customerName);
        }
        
    }
}