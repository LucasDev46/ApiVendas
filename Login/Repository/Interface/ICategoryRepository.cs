using Loja.Models;

namespace Loja.Repository.Interface;

public interface ICategoryRepository : IRepository<Category>
{
    Task<IEnumerable<Category>> GetCategoryProduct();
}
