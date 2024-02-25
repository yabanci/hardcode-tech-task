using Models;

using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories = new List<Category>();

        public IEnumerable<Category> GetAll() => _categories;

        public Category GetById(int id) => _categories.FirstOrDefault(c => c.Id == id);

        public void Add(Category category) => _categories.Add(category);

        public void Update(Category category)
        {
            var existingCategory = GetById(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
            }
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
