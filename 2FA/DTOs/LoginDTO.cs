﻿using System.ComponentModel.DataAnnotations;

namespace _2FA.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
