using Loja.Context;
using Loja.Models;
using Loja.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await Get().FirstOrDefaultAsync(p => p.Name == name);
        }
    }
}
