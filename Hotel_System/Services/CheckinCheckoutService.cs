using Hotel_System.Models;
using Hotel_System.Repositories;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Services
{
        public class CheckinCheckoutService
        {
            private readonly CheckinCheckoutRepository _repo = new CheckinCheckoutRepository();


        public DataTable GetBookingDetails(int bookingId)
        {
            // This calls the method you already wrote in the Repository
            return _repo.GetBookingDetails(bookingId);
        }
        public bool PerformCheckIn(CheckIn ci)
            {
                // Call the repo method you just wrote
                return _repo.PerformCheckIn(ci);
            }
        public DataTable GetPendingIDs()
        {
            return _repo.GetAllPendingBookingIDs();
        }
        public DataTable GetAllOperations()
        {
            // This connects the UI request to the Repository logic
            return _repo.GetAllOperations();
        }
        public bool PerformCheckOut(int bookingID, int roomID, decimal totalAmount, int adminID)
        {
            return _repo.PerformCheckOut(bookingID, roomID, totalAmount, adminID);
        }

        public bool UpdateBookingStatus(int bookingID,
            string status,
            DateTime checkIn,
            DateTime checkOut)
        {
            return _repo.UpdateBookingStatus(
                bookingID,
                status,
                checkIn,
                checkOut);
        }
    }
}
