using Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories = new List<Category>();

        public IEnumerable<Category> GetAll() => _categories;

        public Category GetById(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                throw new ArgumentException($"Category with ID {id} not found.");
            }
            return category;
        }

        public void Add(Category category)
        {
            if (_categories.Any(c => c.Id == category.Id))
            {
                throw new ArgumentException($"Category with ID {category.Id} already exists.");
            }

            _categories.Add(category);
        }

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
