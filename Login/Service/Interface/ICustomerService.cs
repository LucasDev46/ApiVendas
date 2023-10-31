using Loja.Dtos.ClientMapper;
namespace Loja.Service.Interface;
public interface ICustomerService
{
    Task<IEnumerable<CustomerDTO>> GetAllCustomer();
    Task<IEnumerable<CustomerOrderDTO>> GetCustomerOrders();
    Task<CustomerDTO> GetCustomerById(long id);
    Task<CustomerDTO> UpdateCustomer(long id, CustomerDTO entity);
    Task<CustomerDTO> DeleteCustomer(long id);
    Task<CustomerDTO> GetCustomerByCNPJ(string Cnpj);
}
