using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Loja.Models;

public class User : IdentityUser<long>
{
    [Required]
    public override string UserName { get; set; }
    [Required]
    [EmailAddress]
    public override string Email { get; set; }
    [Required]
    public string? Password { get; set; }
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
}
