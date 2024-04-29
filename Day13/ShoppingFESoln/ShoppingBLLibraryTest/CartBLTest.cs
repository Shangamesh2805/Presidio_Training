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
                        var productsInCart = await _cartBL.GetAllProductsInCartAsync();
            Assert.That(productsInCart.Count, Is.EqualTo(1)); // Assert one item added to cart
            Assert.That(productsInCart.First().Quantity, Is.EqualTo(cartItem.Quantity)); // Assert quantity matches
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
            var productsInCart = await _cartBL.GetAllProductsInCartAsync();
            Assert.That(productsInCart.Any(p => p.ProductId == productId), Is.False); // Assert product is removed
        
            
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
            var expectedTotal = cartItems.Sum(item => item.Product.Price * item.Quantity);
            Assert.That(totalAmount, Is.EqualTo(expectedTotal)); // Assert total matches calculation
        
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
            await Assert.That(products, Is.Not.Null);
        }

        [Test]
        public async Task CalculateShippingCharge_SuccessAsync()
        {
            // Arrange
            var totalAmount = 200;

            // Act
            var shippingCharge = await _cartBL.CalculateShippingChargeAsync(totalAmount);
            //Assert
            if (totalAmount >= 100)
            {
                Assert.That(shippingCharge, Is.EqualTo(0)); // Assert free shipping for amount above threshold
            }
            else
            {
                Assert.That(shippingCharge, Is.GreaterThan(0)); // Assert some shipping charge for amount below threshold
            }
            
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

            var expectedDiscountAmount = 10; // Replace with your expected discount value
            Assert.That(discount, Is.GreaterThan(0)); // Assert some discount is applied
            Assert.That(discount, Is.LessThan(products.Sum(p => p.Price))); // Assert discount is less than total price
}
        }

        [Test]
        public async
