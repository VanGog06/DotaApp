﻿using System.ComponentModel.DataAnnotations;

namespace DotaApp.Services.Dtos.Users
{
    public class UsernamePasswordDto
    {
        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
