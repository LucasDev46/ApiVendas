using Loja.Dtos.ProductMapper;
using Loja.Dtos.ClientMapper;

namespace Loja.Dtos.OrderMapper;

public class OrderDTO
{
    public long OrderId { get; set; }
    public ClientDTO Client { get; set; }
    public ICollection<ProductOrderDTO> Products { get; set; }
    public int Quantity { get; set; }
    public decimal TotalValue { get; set; }


    public OrderDTO()
    {
        Products = new List<ProductOrderDTO>();
    }
}
