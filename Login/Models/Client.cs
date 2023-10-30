using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Loja.Models;

public class Client : IdentityUser<long>
{
    
    public long Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }


    [Required]
    public string CNPJ { get; set; }
    public ICollection<Order> Order { get; set; }
    [Required]
    [EmailAddress]
    public string EmailAdress { get; set; }
    public Client()
    {
        Order = new List<Order>();
    }
    // public string? Password { get; set; }
    //[Compare("Password")]
    //public string? ConfirmPassword { get; set; }
}
