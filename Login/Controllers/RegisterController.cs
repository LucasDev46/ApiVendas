using Loja.Dtos.ClientMapper;
using Loja.Errors;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public async Task<IActionResult> Register(CreateCustomerDTO user)
    {
        var result = await _registerService.RegisterClient(user);
        if(result is null)
        {
            return BadRequest(new ResultError { Sucess = false, Message = "Error" });
        }
        return Ok(result);
    }
}
