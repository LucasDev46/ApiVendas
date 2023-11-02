using Loja.Dtos.ProductMapper;
using Loja.Dtos.ClientMapper;
using Loja.Dtos.OrderDTOs;

namespace Loja.Dtos.OrderMapper;

public class OrderDTO
{
    public long OrderId { get; init; }
    public long CustomerId { get; set; }
    public ICollection<ProductsOrderDTO> ProductOrder { get; init; }


    public OrderDTO()
    {
        ProductOrder = new List<ProductsOrderDTO>();
    }
}
