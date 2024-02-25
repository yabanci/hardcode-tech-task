using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Controllers;
using Models;
using Services;
using Xunit;

namespace Tests.Controllers
{
    public class ProductsControllerTests
    {
        private readonly Mock<ILogger<ProductsController>> _loggerMock;
        private readonly Mock<IProductService> _productServiceMock;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _loggerMock = new Mock<ILogger<ProductsController>>();
            _productServiceMock = new Mock<IProductService>();
            _controller = new ProductsController(_loggerMock.Object, _productServiceMock.Object);
        }

        [Fact]
        public void GetAllProducts_ReturnsOkResult()
        {
            var products = new List<Product> { new Product { Id = 1, Name = "Product1" } };
            _productServiceMock.Setup(x => x.GetAllProducts()).Returns(products);
            var result = _controller.GetAllProducts() as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void AddProduct_ValidProduct_ReturnsOkResult()
        {
            var product = new Product { Id = 1, Name = "Product1" };
            var result = _controller.AddProduct(product) as OkResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetProductById_ValidId_ReturnsProduct()
        {
            var productId = 1;
            var product = new Product { Id = productId, Name = "Product1" };
            _productServiceMock.Setup(x => x.GetProductById(productId)).Returns(product);
            var result = _controller.GetProductById(productId);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProduct = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(product, returnedProduct);
        }

        [Fact]
        public void GetProductById_InvalidId_ReturnsNotFoundResult()
        {
            var productId = 100;
            var result = _controller.GetProductById(productId) as NotFoundResult;
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public void AddProduct_DuplicateId_ReturnsConflictResult()
        {
            var existingProduct = new Product { Id = 1, Name = "Existing Product" };
            _productServiceMock.Setup(x => x.GetAllProducts()).Returns(new List<Product> { existingProduct });
            var newProduct = new Product { Id = 1, Name = "New Product" };
            var result = _controller.AddProduct(newProduct) as ConflictResult;
            Assert.NotNull(result);
            Assert.Equal(409, result.StatusCode);
        }
    }
}
