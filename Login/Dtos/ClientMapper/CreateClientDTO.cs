using Loja.Models;
using System.ComponentModel.DataAnnotations;

namespace Loja.Dtos.ClientMapper;

public class CreateClientDTO
{
    public string Name { get; set; }
    public string CNPJ { get; set; }
    public string EmailAdress { get; set; }
    [Required]
    public string? Password { get; set; }
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
}
