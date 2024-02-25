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
    public class CategoriesControllerTests
    {
        private readonly Mock<ILogger<CategoriesController>> _loggerMock;
        private readonly Mock<ICategoryService> _categoryServiceMock;
        private readonly CategoriesController _controller;

        public CategoriesControllerTests()
        {
            _loggerMock = new Mock<ILogger<CategoriesController>>();
            _categoryServiceMock = new Mock<ICategoryService>();
            _controller = new CategoriesController(_loggerMock.Object, _categoryServiceMock.Object);
        }

        [Fact]
        public void GetAllCategories_ReturnsOkResult()
        {
            var categories = new List<Category> { new Category { Id = 1, Name = "Category1" } };
            _categoryServiceMock.Setup(x => x.GetAllCategories()).Returns(categories);
            var result = _controller.GetAllCategories() as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void AddCategory_ValidCategory_ReturnsOkResult()
        {
            var category = new Category { Id = 1, Name = "Category1" };
            var result = _controller.AddCategory(category) as OkResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateCategory_ValidCategory_ReturnsOkResult()
        {
            var category = new Category { Id = 1, Name = "Category1" };
            var result = _controller.UpdateCategory(category.Id, category) as OkResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateCategory_InvalidCategory_ReturnsBadRequestResult()
        {
            var category = new Category { Id = 1, Name = "Category1" };
            var result = _controller.UpdateCategory(category.Id + 1, category) as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void DeleteCategory_ValidCategoryId_ReturnsOkResult()
        {
            var categoryId = 1;
            var result = _controller.DeleteCategory(categoryId) as OkResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeleteCategory_InvalidCategoryId_ReturnsNotFoundResult()
        {
            var categoryId = 100;
            var result = _controller.DeleteCategory(categoryId) as NotFoundResult;
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public void AddCategory_DuplicateId_ReturnsConflictResult()
        {
            var existingCategory = new Category { Id = 1, Name = "Existing Category" };
            _categoryServiceMock.Setup(x => x.GetAllCategories()).Returns(new List<Category> { existingCategory });
            var newCategory = new Category { Id = 1, Name = "New Category" };
            var result = _controller.AddCategory(newCategory) as ConflictResult;
            Assert.NotNull(result);
            Assert.Equal(409, result.StatusCode);
        }
    }
}
