﻿using System.ComponentModel.DataAnnotations;

namespace Payment.Core.DTOs.UserDtos
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; init; }
    }
}
