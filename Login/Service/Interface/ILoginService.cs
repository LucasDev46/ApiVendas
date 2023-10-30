using Loja.Dtos.UserMapper;
using Loja.Models;
namespace Loja.Service.Interface;

public interface ILoginService
{
    Task<UserTokenDTO> Login(LoginUser login);
}
