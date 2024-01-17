﻿using System.ComponentModel.DataAnnotations;

namespace UsersServiceApi.Application.Dtos
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;
    }
}
