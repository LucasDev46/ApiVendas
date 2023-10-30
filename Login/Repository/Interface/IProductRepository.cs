using Loja.Models;

namespace Loja.Repository.Interface;

public interface IProductRepository : IRepository<Product>
{
    Task<Product> GetByNameAsync(string name);
}
