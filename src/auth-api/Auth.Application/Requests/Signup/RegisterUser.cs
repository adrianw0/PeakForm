﻿using System.ComponentModel.DataAnnotations;

namespace Auth.Application.Requests.Signup;

public class RegisterUser
{
    [Required]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}