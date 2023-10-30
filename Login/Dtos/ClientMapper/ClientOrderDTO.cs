using Loja.Dtos.OrderMapper;

namespace Loja.Dtos.ClientMapper;

public class ClientOrderDTO
{
    public long ClientId { get; set; }
    public string Name { get; set; }
    public string CNPJ { get; set; }
    public ICollection<OrderDTO> Order { get; set; }

    public ClientOrderDTO()
    {
        Order = new List<OrderDTO>();
    }
}
