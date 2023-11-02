using AutoMapper;
using Loja.Dtos.ClientMapper;
using Loja.Dtos.ProductMapper;
using Loja.Models;
using Loja.Repository.Interface;
using Loja.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Service;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDTO>> GetAllCustomer()
    {
        var result = await _unitOfWork._customerRepository.SelectAll().ToListAsync();
        if (result is null)
        {
            return null;
        }
        var client = _mapper.Map<List<CustomerDTO>>(result);
        return client;
    }
    public async Task<IEnumerable<CustomerOrderDTO>> GetCustomerOrders()
    {
        var result = await _unitOfWork._customerRepository.SelectAll().Include(p => p.Order).ThenInclude(p => p.ProductOrder).ToListAsync();
        var clienteDto = _mapper.Map<List<CustomerOrderDTO>>(result);
        return clienteDto;
    }

    public async Task<CustomerDTO> GetCustomerByCNPJ(string Cnpj)
    {
        var result = await _unitOfWork._customerRepository.SelectByQuery(p => p.CNPJ == Cnpj);
        if (result is null)
        {
            return null;
        }
        var clientDto = _mapper.Map<CustomerDTO>(result);
        return clientDto;
    }

    public async Task<CustomerDTO> GetCustomerById(long id)
    {
        var result = await _unitOfWork._customerRepository.SelectByQuery(p => p.Id == id);

        if (result is null)
        {
            return null;
        }
        var client = _mapper.Map<CustomerDTO>(result);
        return client;
    }
    public async Task<CustomerDTO> UpdateCustomer(long id, CustomerDTO entity)
    {
        var client = await _unitOfWork._customerRepository.SelectByQuery(p => p.Id == id);

        if (client is null)
        {
            return null;
        }

        client.UserName = entity.Name;
        client.CNPJ = entity.CNPJ;

        _unitOfWork._customerRepository.Update(client);
        await _unitOfWork.Commit();
        return entity;
    }
    public async Task<CustomerDTO> DeleteCustomer(long id)
    {
        var result = await _unitOfWork._customerRepository.SelectByQuery(p => p.Id == id);
        if (result is null)
        {
            return null;
        }
        _unitOfWork._customerRepository.Delete(result);
        await _unitOfWork.Commit();
        var clientDto = _mapper.Map<CustomerDTO>(result);
        return clientDto;
    }
}
