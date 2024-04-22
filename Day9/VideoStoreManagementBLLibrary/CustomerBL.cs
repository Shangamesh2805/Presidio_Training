using System;
using System.Collections.Generic;
using Video_Store_Management_Models;
using VideoStoreManagmentDALLibrary;


namespace VideoStoreManagementBLLibrary
{
    public class CustomerBL : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerBL(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer AddCustomer(Customer customer)
        {
            try
            {
                
                return _customerRepository.AddCustomer(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the customer: {ex.Message}");
                return null;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                _customerRepository.DeleteCustomer(customerId);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the customer: {ex.Message}");
                return false;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _customerRepository.GetAllCustomers();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving all customers: {ex.Message}");
                return null;
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            try
            {
                return _customerRepository.GetCustomerById(customerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the customer: {ex.Message}");
                return null;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                _customerRepository.UpdateCustomer(customer);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the customer: {ex.Message}");
                return false;
            }
        }
    }
}
