using NUnit.Framework;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;

namespace ShoppingDALLibrary.Tests
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        private CustomerRepository _customerRepository;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();
        }

        [TestCase(1, "John Doe")]
        [TestCase(2, "Ram")]
        public void Add_Customer_Success(int id, string name)
        {
            // Arrange
            var customer = new Customer { Id = id, Name = name };

            // Act
            var result = _customerRepository.Add(customer);

            // Assert
            Assert.AreEqual(customer, result);
        }

        [TestCase(1, "Jane Smith")]
        [TestCase(2, " Smith")]
        public void Add_Customer_Fail(int id, string name)
        {
            // Arrange
            var existingCustomer = new Customer { Id = id, Name = name };
            _customerRepository.Add(existingCustomer); // Add an existing customer

            // Act
            var result = _customerRepository.Add(existingCustomer);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase(0, "Invalid Customer")]
        public void Add_Customer_Exception(int id, string name)
        {
            // Arrange
            var invalidCustomer = new Customer { Id = id, Name = name };

            // Act & Assert
            Assert.Throws<Exception>(() => _customerRepository.Add(invalidCustomer));
        }

        [Test]
        public void GetAll_Customers_Success()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe" },
                new Customer { Id = 2, Name = "Jane Smith" }
            };
            foreach (var customer in customers)
            {
                _customerRepository.Add(customer);
            }

            // Act
            var result = _customerRepository.GetAll();

            // Assert
            CollectionAssert.AreEqual(customers, result);
        }

        [TestCase(1)] // Pass: Delete existing customer
        [TestCase(999)] // Fail: Delete non-existing customer
        public void Delete_Customer(int customerId)
        {
            // Arrange
            _customerRepository.Add(new Customer { Id = 1, Name = "John Doe" });

            // Act
            var result = _customerRepository.Delete(customerId);

            // Assert
            if (customerId == 1)
            {
                Assert.IsNotNull(result);
            }
            else
            {
                Assert.IsNull(result);
            }
        }

        [TestCase(1, "John Doe")] // Pass: Get existing customer
        [TestCase(999,"kk")] // Fail: Get non-existing customer
        public void GetByKey_Customer(int customerId, string expectedName)
        {
            // Arrange
            _customerRepository.Add(new Customer { Id = 1, Name = "John Doe" });

            // Act
            var result = _customerRepository.GetByKey(customerId);

            // Assert
            if (expectedName != null)
            {
                Assert.IsNotNull(result);
                Assert.AreEqual(expectedName, result.Name);
            }
            else
            {
                Assert.IsNull(result);
            }
        }

        [TestCase(1, "Updated Name")] 
        [TestCase(999, "New Customer")] 
        public void Update_Customer(int customerId, string updatedName)
        {
            // Arrange
            _customerRepository.Add(new Customer { Id = 1, Name = "John Doe" });

            // Act
            var updatedCustomer = new Customer { Id = customerId, Name = updatedName };
            var result = _customerRepository.Update(updatedCustomer);

            // Assert
            if (customerId == 1)
            {
                Assert.IsNotNull(result);
                Assert.AreEqual(updatedName, result.Name);
            }
            else
            {
                Assert.IsNull(result);
            }
        }
    }
}

