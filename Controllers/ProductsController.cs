using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System;
using System.Collections.Generic;

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
        public IEnumerable<Product> GetAllProducts()
        {
            _logger.LogInformation("Retrieving all products.");
            return _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            _logger.LogInformation($"Retrieving product with ID {id}.");
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                _logger.LogWarning($"Product with ID {id} not found.");
                return NotFound();
            }
            return product;
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
                return StatusCode(500, "An error occurred while processing your request.");
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
                return StatusCode(500, "An error occurred while processing your request.");
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
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("category/{categoryId}")]
        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            _logger.LogInformation($"Retrieving products with category ID {categoryId}.");
            return _productService.GetByCategoryId(categoryId);
        }
    }
}
