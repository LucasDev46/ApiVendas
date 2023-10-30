using System.ComponentModel.DataAnnotations;

namespace Loja.Dtos.ClientMapper;

public class PostClientDTO
{
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string CNPJ { get; set; }
    public string? Password { get; set; }
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
}
