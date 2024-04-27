using System;
using System.Collections.Generic;
using ShoppingBLLibrary.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLLibrary
{
    public class CustomerBL
    {
        private readonly IRepository<int, Customer> _customerRepository;

        public CustomerBL(IRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer AddCustomer(Customer customer)
        {
            try
            {
                int newId = IdGenerator.GenerateId();
                customer.Id = newId;
                return _customerRepository.Add(customer);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the customer.", ex);
            }
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var existingCustomer = _customerRepository.GetByKey(customer.Id);
            if (existingCustomer != null)
            {
                return _customerRepository.Update(customer);
            }
            else
            {
                throw new NoCustomerWithGivenIDException();
            }
        }

        public bool DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetByKey(id);
            if (customer != null)
            {
                var deletedCustomer = _customerRepository.Delete(id);
                return deletedCustomer != null;
            }
            else
            {
                throw new NoCustomerWithGivenIDException();
            }
        }

        public static class IdGenerator
        {
            private static int currentId = 1;

            public static int GenerateId()
            {
                return currentId++;
            }
        }
    }
}
