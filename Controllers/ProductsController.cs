using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IEnumerable<Product> GetAllProducts() => _productService.GetAllProducts();

    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        _productService.AddProduct(product);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        _productService.UpdateProduct(product);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
        return Ok();
    }

    [HttpGet("category/{categoryId}")]
    public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
    {
        return _productService.GetByCategoryId(categoryId);
    }
}
