using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibaray
{
    public interface ICustomerService
    {
        Customer AddCustomer(Customer newCustomer);
        Customer DeleteCustomer(Customer customerToDelete);
        Customer GetCustomerById(int customerId);
        Customer UpdateCustomer(Customer customerToUpdate);
    }
}
