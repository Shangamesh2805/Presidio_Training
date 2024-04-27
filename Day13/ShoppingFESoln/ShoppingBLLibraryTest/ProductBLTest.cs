using ShoppingBLLibrary.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public class ProductBL
    {
        private readonly IRepository<int, Product> _productRepository;
        public int _nextId = 1;
        public object Id { get; private set; }

        public ProductBL(IRepository<int, Product> productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public Product AddProduct(Product product)
        {
            try
            {
                int newId = _nextId;

                var existingProduct = _productRepository.GetByKey(newId);
                if (existingProduct != null)
                {
                    throw new ProductAlreadyExistsException();
                }
                else
                {
                    return _productRepository.Add(product);
                    _nextId++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the product.", ex);
            }
        }

        public Product UpdatePrice(int productId, double newPrice)
        {
            try
            {
                var existingProduct = _productRepository.GetByKey(productId);
                if (existingProduct == null)
                {
                    throw new ProductNotFoundException();
                }

                existingProduct.Price = newPrice;
                return _productRepository.Update(existingProduct);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the product price.", ex);
            }
        }

        public Product UpdateQuantity(int productId, int newQuantity)
        {
            try
            {
                var existingProduct = _productRepository.GetByKey(productId);
                if (existingProduct == null)
                {
                    throw new ProductNotFoundException();
                }

                existingProduct.QuantityInHand = newQuantity;
                return _productRepository.Update(existingProduct);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the product quantity.", ex);
            }
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                var existingProduct = _productRepository.GetByKey(productId);
                if (existingProduct == null)
                {
                    throw new ProductNotFoundException();
                }

                var deletedProduct = _productRepository.Delete(productId);
                return deletedProduct != null;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the product.", ex);
            }
        }
    }
}
