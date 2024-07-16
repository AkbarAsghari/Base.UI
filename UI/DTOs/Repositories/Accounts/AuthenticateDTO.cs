﻿using System.ComponentModel.DataAnnotations;

namespace UI.DTOs.Repositories.Accounts
{
    public class AuthenticateDTO
    {
        [Required(ErrorMessage = "نام کاربری ضروری میباشد")]
        public string UsernameOrEmail { get; set; }
        [Required(ErrorMessage = "رمز عبور ضروری مییباشد")]
        public string Password { get; set; }
    }
}
