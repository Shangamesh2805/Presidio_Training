using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video_Store_Management_Models;

namespace VideoStoreManagementBLLibrary
{
     public interface ICustomerService
    {
        Customer AddCustomer(Customer customer);
        Customer GetCustomerById(int customerId);
        List<Customer> GetAllCustomers();
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int customerId);
    }
}
