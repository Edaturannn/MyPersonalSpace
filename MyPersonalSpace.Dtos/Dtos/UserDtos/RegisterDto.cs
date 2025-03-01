using System;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalSpace.Dtos.Dtos.UserDtos
{
	public class RegisterDto
	{
        public string Username { get; set; }

       
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Şifre en az 6, en fazla 20 karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*\d).{6,}$", ErrorMessage = "Şifre en az bir rakam içermeli ve en az 6 karakter olmalıdır.")]


        public string Password { get; set; }
        public string RoleName { get; set; } = "User";
    }
}

