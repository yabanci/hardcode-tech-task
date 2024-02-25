using Models;

namespace Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetByCategoryId(int categoryId);
    }
}
