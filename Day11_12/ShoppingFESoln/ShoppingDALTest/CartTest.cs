using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class CartRepositoryTests
    {
        private CartRepository _cartRepository;

        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
        }

        [Test]
        public void Add_Cart_Success()
        {
            // Arrange
            var cart = new Cart { Id = 1, CustomerId = 101 };

            // Act
            var result = _cartRepository.Add(cart);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void GetAll_Carts_Success()
        {
            // Arrange
            var cart1 = new Cart { Id = 1, CustomerId = 101 };
            var cart2 = new Cart { Id = 2, CustomerId = 102 };
            _cartRepository.Add(cart1);
            _cartRepository.Add(cart2);

            // Act
            var result = _cartRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Cart>>(result);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.Contains(result, cart1);
            CollectionAssert.Contains(result, cart2);
        }

        [Test]
        public void Delete_Cart_Success()
        {
            // Arrange
            var cart = new Cart { Id = 1, CustomerId = 101 };
            _cartRepository.Add(cart);

            // Act
            var result = _cartRepository.Delete(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void GetByKey_Cart_Success()
        {
            // Arrange
            var cart = new Cart { Id = 1, CustomerId = 101 };
            _cartRepository.Add(cart);

            // Act
            var result = _cartRepository.GetByKey(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void Update_Cart_Success()
        {
            // Arrange
            var cart = new Cart { Id = 1, CustomerId = 101 };
            _cartRepository.Add(cart);

            var updatedCart = new Cart { Id = 1, CustomerId = 102 };

            // Act
            var result = _cartRepository.Update(updatedCart);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedCart, result);
        }

        [Test]
        public void DeleteNonExistingCartThrowsException()
        {
            // Act & Assert
            Assert.Throws<NoCartWithGivenIDException>(() => _cartRepository.Delete(999));
        }

        [Test]
        public void GetByKeyNonExistingCartThrowsException()
        {
            // Act & Assert
            Assert.Throws<NoCartWithGivenIDException>(() => _cartRepository.GetByKey(999));
        }

        [Test]
        public void UpdateNonExistingCartThrowsException()
        {
            // Arrange
            var updatedCart = new Cart { Id = 999, CustomerId = 102 };

            // Act & Assert
            Assert.Throws<NoCartWithGivenIDException>(() => _cartRepository.Update(updatedCart));
        }
        [Test]
        public void Add_Cart_Failure()
        {
            // Arrange
            var cart = new Cart { Id = 1, CustomerId = 101 };
            _cartRepository.Add(cart);

            // Act & Assert
            Assert.Throws<NoCartWithGivenIDException>(() => _cartRepository.Add(cart));
        }

        [Test]
        public void Delete_NonExistingCart_ThrowsException()
        {
            // Act & Assert
            Assert.Throws<NoCartWithGivenIDException>(() => _cartRepository.Delete(999));
        }

        
        [Test]
        public void GetByKey_NonExistingCart_ThrowsException()
        {
            // Act & Assert
            Assert.Throws<NoCartWithGivenIDException>(() => _cartRepository.GetByKey(999));
        }

        
        [Test]
        public void Update_NonExistingCart_ThrowsException()
        {
            // Arrange
            var updatedCart = new Cart { Id = 999, CustomerId = 102 };

            // Act & Assert
            Assert.Throws<NoCartWithGivenIDException>(() => _cartRepository.Update(updatedCart));
        }
    }
}

