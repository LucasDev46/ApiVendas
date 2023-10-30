using Loja.Dtos.OrderMapper;

namespace Loja.Service.Interface;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetAllOrder();
    Task<OrderDTO> GetOrderById(long id);
    Task<OrderDTO> CreateOrder(string cnpj, long productId, int quant);
}
