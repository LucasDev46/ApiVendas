using Loja.Models;

namespace Loja.Repository.Interface;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> SelectAllOrder();

}
