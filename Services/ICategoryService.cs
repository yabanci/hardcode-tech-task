using Models;
using Repositories;

namespace Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
