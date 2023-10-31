using Loja.Dtos.OrderMapper;

namespace Loja.Dtos.ClientMapper;

public class CustomerOrderDTO
{
    public long ClientId { get; init; }
    public string Name { get; init; }
    public string CNPJ { get; init; }
    public ICollection<OrderDTO> Order { get; init; }

    public CustomerOrderDTO()
    {
        Order = new List<OrderDTO>();
    }
}
