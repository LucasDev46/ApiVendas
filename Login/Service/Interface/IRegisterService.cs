using Loja.Dtos.ClientMapper;
namespace Loja.Service.Interface;

public interface IRegisterService
{
    
    Task<ClientDTO> RegisterUser(CreateClientDTO user);
    //Task<UserDTO> CreateManager(UserDTO user);
    //Task<UserDTO> CreateSeller(UserDTO user);
}
