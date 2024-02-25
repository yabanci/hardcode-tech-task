using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System;

namespace Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Retrieving all products.");
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving products: {ex.Message}");
                return BadRequest("An error occurred while retrieving products.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving product with ID {id}.");
                var product = _productService.GetProductById(id);
                if (product == null)
                {
                    _logger.LogWarning($"Product with ID {id} not found.");
                    return NotFound($"Product with ID {id} not found.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving the product: {ex.Message}");
                return BadRequest($"An error occurred while retrieving the product with ID {id}.");
            }
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _productService.AddProduct(product);
                _logger.LogInformation($"Product with ID {product.Id} added successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the product: {ex.Message}");
                return BadRequest($"An error occurred while adding the product: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                _logger.LogWarning("Product ID in the route does not match the ID in the request body.");
                return BadRequest("Product ID in the route does not match the ID in the request body.");
            }

            try
            {
                _productService.UpdateProduct(product);
                _logger.LogInformation($"Product with ID {id} updated successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating the product: {ex.Message}");
                return BadRequest($"An error occurred while updating the product: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                _logger.LogInformation($"Product with ID {id} deleted successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the product: {ex.Message}");
                return BadRequest($"An error occurred while deleting the product: {ex.Message}");
            }
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            try
            {
                _logger.LogInformation($"Retrieving products with category ID {categoryId}.");
                var products = _productService.GetByCategoryId(categoryId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving products with category ID {categoryId}: {ex.Message}");
                return BadRequest($"An error occurred while retrieving products with category ID {categoryId}: {ex.Message}");
            }
        }
    }
}
