using Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public IEnumerable<Product> GetAll() => _products;

        public Product GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new ArgumentException($"Product with ID {id} not found.");
            }
            return product;
        }

        public void Add(Product product) => _products.Add(product);

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.CategoryId = product.CategoryId;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId) => _products.Where(p => p.CategoryId == categoryId);
    }
}
