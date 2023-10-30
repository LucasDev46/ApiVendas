using Loja.Dtos.ClientMapper;
namespace Loja.Service.Interface;
public interface IClientService
{
    Task<IEnumerable<ClientDTO>> GetAllClient();
    Task<IEnumerable<ClientOrderDTO>> GetClientOrders();
    Task<ClientDTO> GetClientById(long id);
    Task<ClientDTO> PutClient(long id, ClientDTO entity);
    Task<ClientDTO> DeleteClient(long id);
    Task<ClientDTO> GetByCNPJ(string Cnpj);
}
