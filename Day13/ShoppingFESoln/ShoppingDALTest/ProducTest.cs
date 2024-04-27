using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class ProducTest
    {
        private ProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository();
        }

        [TestCase(1, "PenDrive")]
        [TestCase(2, "Kite")]
        public void Add_Customer_Success(int id, string name)
        {
            // Arrange
            var product = new Product { Id = id, Name = name };

            // Act
            var result = _productRepository.Add(product);

            // Assert
            Assert.AreEqual(product, result);
        }

        [TestCase(1, "Jane Smith")]
        [TestCase(1, " Smith")]
        public void Add_Product_Fail(int id, string name)
        {
            // Arrange
            var existingCustomer = new Product { Id = id, Name = name };
            _productRepository.Add(existingCustomer); 

            // Act
            var result = _productRepository.Add(existingCustomer);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase(0, "Invalid Product")]
        [TestCase(1, "1")]
        public void Add_Product_Exception(int id, string name)
        {
            // Arrange
            var invalidProduct = new Product { Id = id, Name = name };

            // Act & Assert
            Assert.Throws<Exception>(() => _productRepository.Add(invalidProduct));
        }

        [Test]
        public void GetAll_Product_Success()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Drums" },
                new Product { Id = 2, Name = "Car" }
            };
            foreach (var product in products)
            {
                _productRepository.Add(product);
            }

            // Act
            var result = _productRepository.GetAll();

            // Assert
            CollectionAssert.AreEqual(products, result);
        }

        [TestCase(1)] // Pass: Delete existing product
        [TestCase(999)] // Fail: Delete non-existing product
        public void Delete_Product(int productId)
        {
            // Arrange
            _productRepository.Add(new Product { Id = 1, Name = "John Doe" });

            // Act
            var result = _productRepository.Delete(productId);

            // Assert
            if (productId == 1)
            {
                Assert.IsNotNull(result);
            }
            else
            {
                Assert.IsNull(result);
            }
        }

        [TestCase(1, "Drums")] 
        [TestCase(999, "Kite")]
        public void GetByKey_Product(int productId, string expectedName)
        {
            // Arrange
            _productRepository.Add(new Product { Id = 1, Name = "Drums" });

            // Act
            var result = _productRepository.GetByKey(productId);

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
        [TestCase(999, "New Product")]
        public void Update_Product(int productId, string updatedName)
        {
            // Arrange
            _productRepository.Add(new Product { Id = 1, Name = "Drums" });

            // Act
            var updatedProduct = new Product { Id = productId, Name = updatedName };
            var result = _productRepository.Update(updatedProduct);

            // Assert
            if (productId == 1)
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
    
