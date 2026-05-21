using Hotel_System.Models;
using Hotel_System.Repositories;
using System.Data;

namespace Hotel_System.Services
{
    internal class BookingService
    {
        private readonly BookingRepository _repository = new BookingRepository();

        public int GetNextBookingId()
        {
            return _repository.GetNextBookingId();
        }

        public DataTable GetBookings(string? searchText = null)
        {
            return _repository.GetAll(searchText);
        }

        public bool AddBooking(Booking booking, Customer customer)
        {
            Validate(booking, customer, requireId: false);
            return _repository.Save(booking, customer);
        }

        public bool UpdateBooking(Booking booking, Customer customer)
        {
            Validate(booking, customer, requireId: true);
            return _repository.Update(booking, customer);
        }

        public bool CancelBooking(int bookingId)
        {
            if (bookingId <= 0)
            {
                throw new InvalidOperationException("Please select a booking first.");
            }

            return _repository.Cancel(bookingId);
        }

        private static void Validate(Booking booking, Customer customer, bool requireId)
        {
            if (requireId && booking.BookingID <= 0)
            {
                throw new InvalidOperationException("Please select a booking first.");
            }

            if (booking.RoomID <= 0)
            {
                throw new InvalidOperationException("Please select an available room first.");
            }

            if (string.IsNullOrWhiteSpace(customer.FullName))
            {
                throw new InvalidOperationException("Customer name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(customer.Phone))
            {
                throw new InvalidOperationException("Phone number cannot be empty.");
            }

            if (booking.CheckOutDate < booking.CheckInDate)
            {
                throw new InvalidOperationException("Check-out date cannot be before check-in date.");
            }

            if (booking.Nights <= 0)
            {
                throw new InvalidOperationException("Number of nights must be greater than zero.");
            }

            if (booking.PricePerNight < 0)
            {
                throw new InvalidOperationException("Price per night cannot be negative.");
            }

            if (booking.Discount < 0)
            {
                throw new InvalidOperationException("Discount cannot be negative.");
            }

            if (booking.TotalPrice < 0)
            {
                throw new InvalidOperationException("Total price cannot be negative.");
            }
        }
    }
}
