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

    //[HttpPost("manager")]
    //public async Task<IActionResult> RegisterManagerAsync(UserDTO user)
    //{
    //  var result = await _registerService.CreateManager(user);
    //    if (result is null)
    //    {
    //        return BadRequest("F my man");
    //    }
    //    return Ok(result);
    //}
    //[HttpPost("seller")]
    //public async Task<IActionResult> RegisterSellerAsync(UserDTO user)
    //{
    //    var result = await _registerService.CreateSeller(user);
    //    if(result is null)
    //    {
    //        return BadRequest("Algo deu errado");
    //    }
    //    return Ok(result);
    //}
    [HttpPost("Client")]
    public async Task<IActionResult> Register(CreateClientDTO user)
    {
        var result = await _registerService.RegisterUser(user);
        return Ok(result);
    }
}
