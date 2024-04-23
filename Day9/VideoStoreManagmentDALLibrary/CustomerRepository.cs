using System;
using System.Collections.Generic;
using System.Linq;
using Video_Store_Management_Models;

namespace VideoStoreManagmentDALLibrary
{
    public class CustomerRepository
    {
        private readonly List<Customer> _customers;
        private int CustomerId = 1;

        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }

    public int  GenerateCustomerId()
    {
    
        return CustomerId++;
    }
    
    public Customer AddCustomer(Customer customer)
    {
        try
        {
            customer.Id = GenerateCustomerId();

        if (_customers.Any(customerItem => customerItem.Id == customer.Id))
        {
            throw new InvalidOperationException("Customer with the same ID already exists.");
        }

                _customers.Add(customer);
                return customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the customer: {ex.Message}");
                return null;
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            try
            {
                return _customers.FirstOrDefault(customerItem => customerItem.Id == customerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the customer: {ex.Message}");
                return null;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _customers.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving all customers: {ex.Message}");
                return null;
            }
        }

        public Customer UpdateCustomer(Customer customer)
        {
            try
            {
                var existingCustomer = _customers.FirstOrDefault(customerItem => customerItem.Id == customer.Id);
                if (existingCustomer != null)
                {
                    existingCustomer.Name = customer.Name;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.Gender = customer.Gender;
                    
                    return existingCustomer;
                }
                else
                {
                    throw new KeyNotFoundException($"Customer with ID {customer.Id} does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the customer: {ex.Message}");
                return null;
            }
        }

        public Customer DeleteCustomer(int customerId)
        {
            try
            {
                var customerToRemove = _customers.FirstOrDefault(customerItem => customerItem.Id == customerId);
                if (customerToRemove != null)
                {
                    _customers.Remove(customerToRemove);
                    return customerToRemove;
                }
                else
                {
                    throw new KeyNotFoundException($"Customer with ID {customerId} does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the customer: {ex.Message}");
                return null;
            }
        }
    }
}
