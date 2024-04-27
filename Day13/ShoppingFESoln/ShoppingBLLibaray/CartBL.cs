using ShoppingDALLibrary;
using ShoppingModelLibrary;


namespace ShoppingBLLibrary
{
    public class CartBL
    {
        private readonly IRepository<int, CartItem> _cartRepository;

        public CartBL(IRepository<int, CartItem> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddProductToCartAsync(CartItem cartItem)
        {
            if ((await _cartRepository.GetAllAsync()).Count >= 5)
            {
                throw new CartLimitExceededException();
            }

            await _cartRepository.AddAsync(cartItem);
        }

        public async Task DeleteProductFromCartAsync(int productId)
        {
            var existingProduct = await _cartRepository.GetByKeyAsync(productId);
            if (existingProduct == null)
            {
                throw new ProductNotFoundException();
            }

            await _cartRepository.DeleteAsync(productId);
        }

        public async Task<decimal> CalculateTotalAmountAsync(List<CartItem> cartItems)
        {
            if (cartItems.Count > 0)
            {
                double totalAmount = 0;
                foreach (var item in cartItems)
                {
                    double amount = item.Quantity * item.Product.Price;
                    totalAmount += amount;
                }
                return (decimal)totalAmount;
            }
            else
            {
                throw new CartEmptyException();
            }
        }

        public async Task<List<Product>> GetAllProductsInCartAsync()
        {
            return (List<Product>)await _cartRepository.GetAllAsync();
        }

        public async Task<decimal> CalculateShippingChargeAsync(decimal totalAmount)
        {
            if (totalAmount > 0)
            {
                if (totalAmount < 100)
                {
                    return 100;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new CartEmptyException();
            }
        }

        public async Task<decimal> ApplyDiscountAsync(List<Product> products)
        {
            if (products.Count > 0)
            {
                if (products.Count == 3 && products.Sum(p => p.Price) >= 1500)
                {
                    double discount = products.Sum(p => p.Price) * 0.05;
                    return (decimal)discount;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new CartEmptyException();
            }
        }
    }
}
