using Hotel_System.Models;
using Hotel_System.Repositories;
using System;
using System.Data;

namespace Hotel_System.Services
{
    internal class CustomerService
    {
        private readonly CustomerRepository _repository = new CustomerRepository();

        public bool AddCustomer(Customer customer)
        {
            ValidateCustomer(customer);
            return _repository.Save(customer);
        }

        private static void ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FullName))
                throw new Exception("Name cannot be empty!");

            if (string.IsNullOrWhiteSpace(customer.Phone))
                throw new Exception("Phone number cannot be empty!");
        }

        public DataTable GetCustomerList()
        {
            return _repository.GetAll();
        }

        public Customer? FindByPhone(string phone)
        {
            return string.IsNullOrWhiteSpace(phone) ? null : _repository.FindByPhone(phone);
        }

        public CustomerBookingLookup? FindLatestBookingByPhone(string phone)
        {
            return string.IsNullOrWhiteSpace(phone) ? null : _repository.FindLatestBookingByPhone(phone);
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer.CustomerID <= 0) return false;
            ValidateCustomer(customer);
            return _repository.Update(customer);
        }

        public bool DeleteCustomer(int id)
        {
            return _repository.Delete(id);
        }

        public DataTable GetCustomerReport(DateTime? fromDate, DateTime? toDate,
                                           string customerName, string roomType, string roomNumber)
        {
            return _repository.GetCustomerReport(fromDate, toDate, customerName, roomType, roomNumber);
        }

        public DataTable GetAllRoomTypes() => _repository.GetAllRoomTypes();
    }
}
