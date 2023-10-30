﻿using System.ComponentModel.DataAnnotations;

namespace Loja.Dtos.UserMapper;

public class UserDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string? Password { get; set; }
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
}
