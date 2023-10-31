using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Loja.Models;

public class Customer : IdentityUser<long>
{

    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    public string CNPJ { get; set; }
    public ICollection<Order> Order { get; set; }
    [Required]
    [EmailAddress]
    public string EmailAdress { get; set; }
    public Customer()
    {
        Order = new List<Order>();
    }
}
