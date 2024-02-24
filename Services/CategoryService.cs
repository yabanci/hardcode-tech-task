using System.Collections.Generic;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IEnumerable<Category> GetAllCategories() => _categoryRepository.GetAll();

    public void AddCategory(Category category) => _categoryRepository.Add(category);

    public void UpdateCategory(Category category) => _categoryRepository.Update(category);

    public void DeleteCategory(int id) => _categoryRepository.Delete(id);
}
