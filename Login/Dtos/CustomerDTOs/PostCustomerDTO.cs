using System.ComponentModel.DataAnnotations;

namespace Loja.Dtos.ClientMapper;

public class PostCustomerDTO
{
    public string Name { get; init; }
    [EmailAddress]
    public string Email { get; init; }
    public string CNPJ { get; init; }
    public string? Password { get; init; }
    [Compare("Password")]
    public string? ConfirmPassword { get; init; }
}
