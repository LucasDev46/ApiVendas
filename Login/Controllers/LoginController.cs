using Loja.Models;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers;

[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUser loginDto)
    {
        var result = await _loginService.Login(loginDto);
        if (result is null)
        {
            return BadRequest("F");
        }
        return Ok(result);

    }
}
