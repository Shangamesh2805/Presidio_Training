using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingBLLibrary.Exceptions;

namespace ShoppingBLLibrary
{
    public class CartBL
    {
        private readonly IRepository<int, CartItem> _cartRepository;

        public CartBL(IRepository<int, CartItem> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public CartBL()
        {
        }

        public void AddProductToCart(CartItem cartItem)
        {
            
            if (_cartRepository.GetAll().Count >= 5)
            {
                throw new CartLimitExceededException();
            }

            
            _cartRepository.Add(cartItem);
        }

        public void DeleteProductFromCart(int productId)
        {
            
            var existingProduct = _cartRepository.GetByKey(productId);
            if (existingProduct == null)
            {
                throw new ProductNotFoundException();
            }

            _cartRepository.Delete(productId);
        }

        public decimal CalculateTotalAmount(List<CartItem> cartItems)
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
        public List<Product> GetAllProductsInCart()
        {
            return (List<Product>)_cartRepository.GetAll();
        }

        public decimal CalculateShippingCharge(decimal totalAmount)
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

        public decimal ApplyDiscount(List<Product> products)
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
