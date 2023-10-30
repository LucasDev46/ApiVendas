using Loja.Config;
using Loja.Dtos.UserMapper;
using Loja.Models;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Loja.Service;

public class LoginService : ILoginService
{
    private readonly UserManager<IdentityUser<long>> _userManager;
    private readonly SignInManager<IdentityUser<long>> _signInManager;
    private readonly IConfiguration _config;

    public LoginService(UserManager<IdentityUser<long>> userManager, IConfiguration config, SignInManager<IdentityUser<long>> signInManager)
    {
        _userManager = userManager;
        _config = config;
        _signInManager = signInManager;
    }

    public async Task<UserTokenDTO> Login(LoginUser login)
    {
        var result = await _userManager.FindByNameAsync(login.UserName);
        if (result is null)
        {
            return null;
        }
        var check = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, isPersistent: false, lockoutOnFailure: false);

        if (!check.Succeeded) {
            return null;
        }
       
        var token = await GenerateTokenString(login);
        return token;
        
    }

    private async Task<UserTokenDTO> GenerateTokenString(LoginUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddHours(double.Parse(_config["TokenConfig:HourExpiration"]));

        var findUser = await _userManager.FindByNameAsync(user.UserName);

        IList<string> userRoles = await _userManager.GetRolesAsync(findUser);
        var claims = new List<Claim>();
        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken
            (
             issuer: _config["TokenConfig:Issuer"],
             audience: _config["TokenConfig:Audience"],
             claims: claims,
             expires: expiration,
             signingCredentials: credential
             );

        return new UserTokenDTO
        {
            Authenticated = true,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Message = "Sucess",
            Expiration = expiration,
        };
    }
}
