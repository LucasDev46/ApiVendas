
using System.ComponentModel.DataAnnotations;

namespace Loja.Models;
public class LoginUser
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}
