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
            if (string.IsNullOrEmpty(customer.FullName))
                throw new Exception("Name cannot be empty!");

            return _repository.Save(customer);
        }

        public DataTable GetCustomerList()
        {
            return _repository.GetAll();
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer.CustomerID <= 0) return false;
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
