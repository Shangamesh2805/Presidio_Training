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
    [TestFixture]
    public class CartItemRepositoryTests
    {
        private CartItemRepository _cartItemRepository;

        [SetUp]
        public void Setup()
        {
            _cartItemRepository = new CartItemRepository();
        }

        [TestCase(1)] // Success: Delete existing cart item
        public void Delete_CartItem_Success(int cartItemId)
        {
            // Arrange
            var cartItem = new CartItem { CartId = cartItemId, ProductId = 101, Quantity = 2 };
            _cartItemRepository.Add(cartItem);

            // Act
            var result = _cartItemRepository.Delete(cartItemId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase(999)] // Failure: Delete non-existing cart item
        public void Delete_CartItem_Failure(int cartItemId)
        {
            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIDException>(() => _cartItemRepository.Delete(cartItemId));
        }

        [TestCase(0)] // Exception: Delete cart item with invalid ID
        public void Delete_CartItem_Exception(int cartItemId)
        {
            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIDException>(() => _cartItemRepository.Delete(cartItemId));
        }

        [TestCase(1)] // Success: Get existing cart item
        public void GetByKey_CartItem_Success(int cartItemId)
        {
            // Arrange
            var cartItem = new CartItem { CartId = cartItemId, ProductId = 101, Quantity = 2 };
            _cartItemRepository.Add(cartItem);

            // Act
            var result = _cartItemRepository.GetByKey(cartItemId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase(999)] // Failure: Get non-existing cart item
        public void GetByKey_CartItem_Failure(int cartItemId)
        {
            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIDException>(() => _cartItemRepository.GetByKey(cartItemId));
        }

        [TestCase(1)] // Success: Update existing cart item
        public void Update_CartItem_Success(int cartItemId)
        {
            // Arrange
            var cartItem = new CartItem { CartId = cartItemId, ProductId = 101, Quantity = 2 };
            _cartItemRepository.Add(cartItem);

            var updatedCartItem = new CartItem { CartId = cartItemId, ProductId = 101, Quantity = 5 };

            // Act
            var result = _cartItemRepository.Update(updatedCartItem);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedCartItem.Quantity, result.Quantity);
        }

        [TestCase(999)] // Failure: Update non-existing cart item
        public void Update_CartItem_Failure(int cartItemId)
        {
            // Arrange
            var updatedCartItem = new CartItem { CartId = cartItemId, ProductId = 101, Quantity = 5 };

            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIDException>(() => _cartItemRepository.Update(updatedCartItem));
        }
        [Test]
        public void Update_NonExistingCartItem_ThrowsException()
        {
            // Arrange
            var updatedCartItem = new CartItem { CartId = 999, ProductId = 101, Quantity = 5 };

            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIDException>(() => _cartItemRepository.Update(updatedCartItem));
        }
        [Test]
        public void Add_CartItem_Success()
        {
            // Arrange
            var cartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 2 };

            // Act
            var result = _cartItemRepository.Add(cartItem);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cartItem, result);
        }

        [Test]
        public void Add_CartItem_Failure()
        {
            // Arrange
            var cartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 2 };
            _cartItemRepository.Add(cartItem);

            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIDException>(() => _cartItemRepository.Add(cartItem));
        }

        [Test]
        public void GetAll_CartItems_Success()
        {
            // Arrange
            var cartItem1 = new CartItem { CartId = 1, ProductId = 101, Quantity = 2 };
            var cartItem2 = new CartItem { CartId = 2, ProductId = 102, Quantity = 3 };
            _cartItemRepository.Add(cartItem1);
            _cartItemRepository.Add(cartItem2);

            // Act
            var result = _cartItemRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<CartItem>>(result);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.Contains(result, cartItem1);
            CollectionAssert.Contains(result, cartItem2);
        }

        [Test]
        public void GetAll_CartItems_EmptyList()
        {
            // Act
            var result = _cartItemRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<CartItem>>(result);
            Assert.AreEqual(0, result.Count);
        }
    }

}
