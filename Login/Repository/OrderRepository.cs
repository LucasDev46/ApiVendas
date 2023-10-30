using Loja.Context;
using Loja.Models;
using Loja.Repository.Interface;

namespace Loja.Repository;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
}
