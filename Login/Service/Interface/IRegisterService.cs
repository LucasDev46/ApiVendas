using Loja.Dtos.ClientMapper;
namespace Loja.Service.Interface;

public interface IRegisterService
{
    
    Task<ClientDTO> RegisterClient(CreateClientDTO user);
}
