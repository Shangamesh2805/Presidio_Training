using ShoppingBLLibrary.Exceptions;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : IRepository<int, CartItem>
    {
        private readonly List<CartItem> items = new List<CartItem>();

       

        public async Task AddAsync(CartItem cartItem)
        {
            if (items.Count >= 5)
            {
                throw new CartLimitExceededException();
            }

            items.Add(cartItem);
        }

        public CartItem Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int productId)
        {
            var existingProduct = await GetByKeyAsync(productId);
            if (existingProduct == null)
            {
                throw new ProductNotFoundException();
            }

            items.Remove(existingProduct);
        }

       

        public async Task<List<CartItem>> GetAllAsync()
        {
            return items.ToList();
        }

       

        public async Task<CartItem> GetByKeyAsync(int productId)
        {
            return items.FirstOrDefault(item => item.ProductId == productId);
        }

        
    }
}
