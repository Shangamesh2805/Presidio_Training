using ShoppingBLLibrary.Exceptions;
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
            // Create a mock repository for testing (assuming mock library supports async)
            var mockRepository = new MockRepository<int, CartItem>();
            _cartBL = new CartBL(mockRepository);
        }

        [Test]
        public async Task AddProductToCart_SuccessAsync()
        {
            // Arrange
            var cartItem = new CartItem { Product = new Product(), Quantity = 1 };

            // Act
            object value = await Assert.DoesNotThrowAsync(() => _cartBL.AddProductToCartAsync(cartItem));

            // Assert
            // Add your assertions here (e.g., verify mock repository was called with expected data)
        }

        [Test]
        public async Task AddProductToCart_CartLimitExceededAsync()
        {
            // Arrange
            var cartItem = new CartItem { Product = new Product(), Quantity = 1 };

            // Act and Assert
            await Assert.ThrowsAsync<CartLimitExceededException>(() => _cartBL.AddProductToCartAsync(cartItem));
        }

        [Test]
        public async Task DeleteProductFromCart_SuccessAsync()
        {
            // Arrange
            var productId = 1;

            // Act
            await Assert.DoesNotThrowAsync(() => _cartBL.DeleteProductFromCartAsync(productId));

            // Assert
            // Add your assertions here (e.g., verify mock repository was called with expected ID)
        }

        [Test]
        public async Task DeleteProductFromCart_ProductNotFoundAsync()
        {
            // Arrange
            var productId = 1;

            // Act and Assert
            await Assert.ThrowsAsync<ProductNotFoundException>(() => _cartBL.DeleteProductFromCartAsync(productId));
        }

        [Test]
        public async Task CalculateTotalAmount_SuccessAsync()
        {
            // Arrange
            var cartItems = new List<CartItem>
      {
        new CartItem { Product = new Product { Price = 10 }, Quantity = 2 },
        new CartItem { Product = new Product { Price = 20 }, Quantity = 3 }
      };

            // Act
            var totalAmount = await _cartBL.CalculateTotalAmountAsync(cartItems);

            // Assert
            // Add your assertions here (e.g., verify total amount is calculated correctly)
        }

        [Test]
        public async Task CalculateTotalAmount_CartEmptyAsync()
        {
            // Arrange
            var cartItems = new List<CartItem>();

            // Act and Assert
            await Assert.ThrowsAsync<CartEmptyException>(() => _cartBL.CalculateTotalAmountAsync(cartItems));
        }

        [Test]
        public async Task GetAllProductsInCart_SuccessAsync()
        {
            // Act
            var products = await _cartBL.GetAllProductsInCartAsync();

            // Assert
            // Add your assertions here (e.g., verify returned products are as expected)
        }

        [Test]
        public async Task CalculateShippingCharge_SuccessAsync()
        {
            // Arrange
            var totalAmount = 200;

            // Act
            var shippingCharge = await _cartBL.CalculateShippingChargeAsync(totalAmount);

            // Assert
            // Add your assertions here (e.g., verify shipping charge is calculated correctly)
        }

        [Test]
        public async Task CalculateShippingCharge_CartEmptyAsync()
        {
            // Arrange
            var totalAmount = 0;

            // Act and Assert
            await Assert.ThrowsAsync<CartEmptyException>(() => _cartBL.CalculateShippingChargeAsync(totalAmount));
        }

        [Test]
        public async Task ApplyDiscount_SuccessAsync()
        {
            // Arrange
            var products = new List<Product>
      {
        new Product { Price = 500 },
        new Product { Price = 600 },
        new Product { Price = 400 }
      };

            // Act
            var discount = await _cartBL.ApplyDiscountAsync(products);

            // Assert
            // Add your assertions here (e.g., verify discount is calculated correctly)
        }

        [Test]
        public async
