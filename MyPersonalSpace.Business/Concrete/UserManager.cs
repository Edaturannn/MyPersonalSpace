﻿using System.Security.Cryptography;
using System.Text;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Http;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.Business.JwtServices;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.DataAccess.Concrete;
using MyPersonalSpace.Dtos.Dtos.UserDtos;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IJwtService _jwtService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Context _context;

        public UserManager(IUserDal userDal, IJwtService jwtService, IHttpContextAccessor httpContextAccessor, Context context)
        {
            _userDal = userDal;
            _jwtService = jwtService;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(RegisterDto registerDto)
        {
            // Kullanıcı adı mevcut mu?
            if (await _userDal.UserExistsAsync(registerDto.Username))
            {
                return false;
            }

            // Şifreyi hashle ve salt ile kaydet
            string hash = Argon2.Hash(registerDto.Password);
            //registerDto.RoleName = "User";
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                RoleName = registerDto.RoleName,
                PasswordHash = hash,
            };

            await _userDal.AddAsync(user);
            return true;
        }

        public async Task<LoginResultDto?> LoginUserAsync(LoginDto loginDto)
        {
            // Kullanıcı mevcut mu?
            var user = _userDal.GetUserByUsername(loginDto.Username);
            if (user == null)
            {
                return null;
            }


            if (Argon2.Verify(user.PasswordHash, loginDto.Password) != true)
            {
                return null;
            }

            
          

            Guid guid = Guid.NewGuid();
            var sessionId = guid.ToString();

            // Oturumun 30 dakika sonra sona ermesini sağla
            var expirationTime = DateTime.UtcNow.AddMinutes(30);

            // Yeni session kaydı oluştur
            var session = new Session
            {
                SessionId = guid,
                Username = loginDto.Username,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = expirationTime
            };

            // Veritabanına kaydet
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();


            var accessToken = _jwtService.GenerateToken(sessionId);

            // String'i cookie'ye ekle
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                httpContext.Response.Cookies.Append("MyPersonalSpace", accessToken, new CookieOptions
                {
                    HttpOnly = true, // Güvenlik için sadece HTTP üzerinden erişim
                    Secure = true, // Sadece HTTPS üzerinden kullanılabilir
                    SameSite = SameSiteMode.Strict, // CSRF koruması için SameSite modunu ayarla
                    Expires = DateTime.UtcNow.AddMinutes(60) // Süre sonu
                });
            }


            // repo'dan user modelini al


            return new LoginResultDto { Token = accessToken, RoleName = user.RoleName };
        }




        private static string ComputeSha256Hash(string input, string salt)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input + salt);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private static string GenerateSalt()
        {
            var randomBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public async Task<IEnumerable<User>> TGetAllAsync()
        {
            return await _userDal.GetAllAsync();
        }

        public async Task<User> TGetByIdAsync(int id)
        {
            return await _userDal.GetByIdAsync(id);
        }

        public async Task TAddAsync(User t)
        {
            await _userDal.AddAsync(t);
        }

        public async Task TUpdateAsync(User t)
        {
            await _userDal.UpdateAsync(t);
        }

        public async Task TDeleteAsync(int id)
        {
            await _userDal.DeleteAsync(id);
        }
    }
}

