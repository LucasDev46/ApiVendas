using Loja.Context;
using Loja.Dtos;
using Loja.Models;
using Loja.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Category>> GetCategoryProduct()
    {
        return await GetAll().Include(x => x.Products).ToListAsync();
      
    }
}
