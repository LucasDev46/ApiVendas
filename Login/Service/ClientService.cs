using AutoMapper;
using Loja.Dtos.ClientMapper;
using Loja.Dtos.ProductMapper;
using Loja.Models;
using Loja.Repository.Interface;
using Loja.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Service;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDTO>> GetAllClient()
    {
        var result = await _unitOfWork._clientRepository.Get().ToListAsync();
        if (result is null)
        {
            return null;
        }
        var client = _mapper.Map<List<ClientDTO>>(result);
        return client;
    }
    public async Task<IEnumerable<ClientOrderDTO>> GetClientOrders()
    {
        var result = await _unitOfWork._clientRepository.Get().Include(p => p.Order).ThenInclude(p => p.Products).ToListAsync();
        var clienteDto = _mapper.Map<List<ClientOrderDTO>>(result);
        return clienteDto;
    }

    public async Task<ClientDTO> GetByCNPJ(string Cnpj)
    {
        var result = await _unitOfWork._clientRepository.GetByQuery(p => p.CNPJ == Cnpj);
        if (result is null)
        {
            return null;
        }
        var clientDto = _mapper.Map<ClientDTO>(result);
        return clientDto;
    }

    public async Task<ClientDTO> GetClientById(long id)
    {
        var result = await _unitOfWork._clientRepository.GetByQuery(p => p.Id == id);
       
        if (result is null)
        {
            return null;
        }
        var client = _mapper.Map<ClientDTO>(result);
        return client;
    }
    public async Task<ClientDTO> PutClient(long id, ClientDTO entity)
    {
        var client = await _unitOfWork._clientRepository.GetByQuery(p => p.Id == id);
      
        if(client is null)
        {
            return null;
        }

        client.UserName = entity.Name;
        client.CNPJ = entity.CNPJ;
       
        _unitOfWork._clientRepository.Update(client);
        await _unitOfWork.Commit();
        var clientDto = _mapper.Map<ClientDTO>(client);
        return clientDto;
    }
    public async Task<ClientDTO> DeleteClient(long id)
    {
        var result = await _unitOfWork._clientRepository.GetByQuery(p => p.Id == id);
        if (result is null)
        {
            return null;
        }
        _unitOfWork._clientRepository.Delete(result);
        await _unitOfWork.Commit();
        var clientDto = _mapper.Map<ClientDTO>(result);
        return clientDto;
    }
}
