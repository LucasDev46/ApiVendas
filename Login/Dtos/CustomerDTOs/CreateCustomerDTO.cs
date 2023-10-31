using Loja.Models;
using System.ComponentModel.DataAnnotations;

namespace Loja.Dtos.ClientMapper;

public class CreateCustomerDTO
{
    public string Name { get; init; }
    public string CNPJ { get; init; }
    public string EmailAdress { get; init; }
    [Required]
    public string? Password { get; init; }
    [Compare("Password")]
    public string? ConfirmPassword { get; init; }
}
