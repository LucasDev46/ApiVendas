using Loja.Errors;
using Loja.Models;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginUser loginDto)
    {
        var result = await _loginService.Login(loginDto);
        if (result is null)
        {
            return BadRequest(new ResultError { Sucess = false, Message = "Error" });
        }
        return Ok(result);

    }
}
