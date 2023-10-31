using AutoMapper;
using Loja.Config.Enum;
using Loja.Dtos.ClientMapper;
using Loja.Models;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Identity;

namespace Loja.Service;

public class RegisterService : IRegisterService
{
    private readonly UserManager<IdentityUser<long>> _userManager;
   
    private readonly IMapper _mapper;
    public RegisterService(UserManager<IdentityUser<long>> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<CustomerDTO> RegisterClient(CreateCustomerDTO user)
    {
        var clientEntity = _mapper.Map<Customer>(user);
        var result = await _userManager.CreateAsync(clientEntity, user.Password);

            if (result.Succeeded)
            {
               var aio = await _userManager.AddToRoleAsync(clientEntity, Role.Client.ToString());
                if (!aio.Succeeded)
                {
                    return null;
                }
            }
          
        var clientDto = _mapper.Map<CustomerDTO>(clientEntity);
        return clientDto;
    }
}
