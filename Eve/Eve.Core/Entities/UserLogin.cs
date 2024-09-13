using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eve.Core.Entities;

public class UserLogin : _BaseEntity
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Pass { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
}
