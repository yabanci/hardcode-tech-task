using Models;
using Repositories;

using System.Collections.Generic;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts() => _productRepository.GetAll();

        public IEnumerable<Product> GetByCategoryId(int categoryId) => _productRepository.GetByCategoryId(categoryId);

        public Product GetProductById(int id) => _productRepository.GetById(id);

        public void AddProduct(Product product) => _productRepository.Add(product);

        public void UpdateProduct(Product product) => _productRepository.Update(product);

        public void DeleteProduct(int id) => _productRepository.Delete(id);
    }
}
