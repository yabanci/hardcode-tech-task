using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IEnumerable<Category> GetAllCategories() => _categoryService.GetAllCategories();

    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        _categoryService.AddCategory(category);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        _categoryService.UpdateCategory(category);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        _categoryService.DeleteCategory(id);
        return Ok();
    }
}
