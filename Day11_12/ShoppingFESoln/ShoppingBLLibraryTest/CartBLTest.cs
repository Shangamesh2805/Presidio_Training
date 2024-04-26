using ShoppingModelLibrary;

namespace ShoppingBLLibrary.Tests
{
    [TestFixture]
    public class CartBLTests
    {
        private CartBL _cartBL;

        [SetUp]
        public void Setup()
        {
            // Create a mock repository for testing
            var mockRepository = new MockRepository<int, CartItem>();
            _cartBL = new CartBL(mockRepository);
        }

        [Test]
        public void AddProductToCart_Success()
        {
            // Arrange
            var cartItem = new CartItem { Product = new Product(), Quantity = 1 };

            // Act
            Assert.DoesNotThrow(() => _cartBL.AddProductToCart(cartItem));

            // Assert
            // Add your assertions here
        }

        [Test]
        public void AddProductToCart_CartLimitExceeded()
        {
            // Arrange
            var cartItem = new CartItem { Product = new Product(), Quantity = 1 };

            // Act and Assert
            Assert.Throws<CartLimitExceededException>(() => _cartBL.AddProductToCart(cartItem));
        }

        [Test]
        public void DeleteProductFromCart_Success()
        {
            // Arrange
            var productId = 1;

            // Act
            Assert.DoesNotThrow(() => _cartBL.DeleteProductFromCart(productId));

            // Assert
            // Add your assertions here
        }

        [Test]
        public void DeleteProductFromCart_ProductNotFound()
        {
            // Arrange
            var productId = 1;

            // Act and Assert
            Assert.Throws<ProductNotFoundException>(() => _cartBL.DeleteProductFromCart(productId));
        }

        [Test]
        public void CalculateTotalAmount_Success()
        {
            // Arrange
            var cartItems = new List<CartItem>
            {
                new CartItem { Product = new Product { Price = 10 }, Quantity = 2 },
                new CartItem { Product = new Product { Price = 20 }, Quantity = 3 }
            };

            // Act
            var totalAmount = _cartBL.CalculateTotalAmount(cartItems);

            // Assert
            // Add your assertions here
        }

        [Test]
        public void CalculateTotalAmount_CartEmpty()
        {
            // Arrange
            var cartItems = new List<CartItem>();

            // Act and Assert
            Assert.Throws<CartEmptyException>(() => _cartBL.CalculateTotalAmount(cartItems));
        }

        [Test]
        public void GetAllProductsInCart_Success()
        {
            // Act
            var products = _cartBL.GetAllProductsInCart();

            // Assert
            // Add your assertions here
        }

        [Test]
        public void CalculateShippingCharge_Success()
        {
            // Arrange
            var totalAmount = 200;

            // Act
            var shippingCharge = _cartBL.CalculateShippingCharge(totalAmount);

            // Assert
            // Add your assertions here
        }

        [Test]
        public void CalculateShippingCharge_CartEmpty()
        {
            // Arrange
            var totalAmount = 0;

            // Act and Assert
            Assert.Throws<CartEmptyException>(() => _cartBL.CalculateShippingCharge(totalAmount));
        }

        [Test]
        public void ApplyDiscount_Success()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Price = 500 },
                new Product { Price = 600 },
                new Product { Price = 400 }
            };

            // Act
            var discount = _cartBL.ApplyDiscount(products);

            // Assert
            // Add your assertions here
        }

        [Test]
        public void ApplyDiscount_CartEmpty()
        {
            // Arrange
            var products = new List<Product>();

            // Act and Assert
            Assert.Throws<CartEmptyException>(() => _cartBL.ApplyDiscount(products));
        }
    }
}
