using Loja.Context;
using Loja.Models;
using Loja.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Repository;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> SelectAllOrder()
    {
        return await SelectAll().Include(p => p.CustomerId).Include(p => p.ProductOrder).ToListAsync();
    }
}
