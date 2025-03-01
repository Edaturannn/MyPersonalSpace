using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Business.Concrete;
using MyPersonalSpace.Dtos.Dtos.UserDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPersonalSpace.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager _userManager;

        public AuthController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geçersiz giriş.");
            }

            bool success = await _userManager.RegisterUserAsync(registerDto);
            if (success)
            {
                return Ok("Kayıt başarılı.");
            }
            return BadRequest("Kullanıcı adı zaten mevcut.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geçersiz giriş.");
            }

            var values = await _userManager.LoginUserAsync(loginDto);
            if (values != null)
            {
                return Ok(values);
            }


            return Unauthorized("Kullanıcı adı veya şifre hatalı.");
        }
    }
}

