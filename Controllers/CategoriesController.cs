using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System;

namespace Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                _logger.LogInformation("Retrieving all categories.");
                var categories = _categoryService.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving categories: {ex.Message}");
                return BadRequest("An error occurred while retrieving categories.");
            }
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                _categoryService.AddCategory(category);
                _logger.LogInformation($"Category with ID {category.Id} added successfully.");
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"An error occurred while adding the category: {ex.Message}");
                return Conflict($"Category with ID {category.Id} already exists.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the category: {ex.Message}");
                return BadRequest($"An error occurred while adding the category: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                _logger.LogWarning("Category ID in the route does not match the ID in the request body.");
                return BadRequest("Category ID in the route does not match the ID in the request body.");
            }

            try
            {
                _categoryService.UpdateCategory(category);
                _logger.LogInformation($"Category with ID {id} updated successfully.");
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"An error occurred while updating the category: {ex.Message}");
                return NotFound($"Category with ID {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating the category: {ex.Message}");
                return BadRequest($"An error occurred while updating the category: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                _logger.LogInformation($"Category with ID {id} deleted successfully.");
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"An error occurred while deleting the category: {ex.Message}");
                return NotFound($"Category with ID {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the category: {ex.Message}");
                return BadRequest($"An error occurred while deleting the category: {ex.Message}");
            }
        }
    }
}
