using Loja.Context;
using Loja.Models;
using Loja.Repository.Interface;

namespace Loja.Repository;

public class ProductOrderRepository : Repository<ProductOrder>, IProductOrderRepository
{
    public ProductOrderRepository(AppDbContext context) : base(context)
    {
    }
}
