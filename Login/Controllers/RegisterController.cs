using Loja.Dtos.ClientMapper;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Mvc;


namespace Loja.Controllers;

[Route("[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    private readonly IRegisterService _registerService;
   

    public RegisterController(IRegisterService tokenService)
    {
        _registerService = tokenService;
    }

    [HttpPost()]
    public async Task<IActionResult> Register(CreateClientDTO user)
    {
        var result = await _registerService.RegisterClient(user);
        return Ok(result);
    }
}
