using Loja.Dtos.ProductMapper;
using Loja.Dtos.ClientMapper;

namespace Loja.Dtos.OrderMapper;

public class OrderDTO
{
    public long OrderId { get; init; }
    public CustomerDTO Client { get; init; }
    public ICollection<ProductOrderDTO> Products { get; init; }
    public int Quantity { get; init; }
    public decimal TotalValue { get; init; }


    public OrderDTO()
    {
        Products = new List<ProductOrderDTO>();
    }
}
