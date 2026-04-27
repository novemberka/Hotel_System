using Hotel_System.Models;
using Hotel_System.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Services
{
    internal class CustomerService
    {
        private CustomerRepository _repository = new CustomerRepository();

        public bool AddCustomer(Customer customer)
        {
            // Business Logic: e.g., Don't add if name is empty
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
            // You can add logic here: e.g., don't update if ID is 0
            if (customer.CustomerID <= 0) return false;
            return _repository.Update(customer);
        }

        public bool DeleteCustomer(int id)
        {
            return _repository.Delete(id);
        }
    }
}
