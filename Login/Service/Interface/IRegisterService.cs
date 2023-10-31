using Loja.Dtos.ClientMapper;
namespace Loja.Service.Interface;

public interface IRegisterService
{
    
    Task<CustomerDTO> RegisterClient(CreateCustomerDTO user);
}
