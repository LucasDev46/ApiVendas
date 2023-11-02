using Loja.Dtos.OrderMapper;
using Loja.Models;

namespace Loja.Service.Interface;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetAllOrder();
    Task<OrderDTO> GetOrderById(long id);
    Task<OrderDTO> CreateOrder(OrderDTO order);
}
