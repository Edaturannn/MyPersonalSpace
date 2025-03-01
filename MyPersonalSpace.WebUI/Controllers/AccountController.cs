﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPersonalSpace.DataAccess.Concrete;
using MyPersonalSpace.Entities.Concrete;
using Isopoh.Cryptography.Argon2;
using MyPersonalSpace.WebUI.Areas.User.Models;
namespace MyPersonalSpace.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly Context _context;
        public AccountController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if(user == null)
            {
                return BadRequest("E-posta adresi kayıtlı değil.");
            }

            //Eski tokenları temizle.
            var oldTokens = _context.PasswordResetTokens.Where(y => y.Email == email);
            _context.PasswordResetTokens.RemoveRange(oldTokens);
            await _context.SaveChangesAsync();

            //Yeni bir token oluştur
            string token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

            var resetToken = new PasswordResetToken
            {
                Email = email,
                Token = token,
                ExpireTime = DateTime.UtcNow.AddHours(1) //1 saat geçerli token ürettim.
            };

            _context.PasswordResetTokens.Add(resetToken);
            await _context.SaveChangesAsync();

            //Şifre sıfırlama bağlantısı oluştur.
            var resetLink = Url.Action("ResetPassword", "Account", new { token = token }, Request.Scheme);

            //Kullanıcıya e-posta gönder.
            SendEmail(email, resetLink);

            return Ok("Şifre sıfırlama bağlantısı e-posta adresinize gönderildi.");
        }
        private void SendEmail(string email,string resetLink)
        {
            try
            {
               using(var client = new SmtpClient("smtp.gmail.com")) //SMTP Sunucunuzu yazın google apı istek yapar. kendi içinde çalışır.
                {
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("eeeedaturannn@gmail.com", "bizv chfs sioq evgn");
                    client.EnableSsl = true;
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("your-email@example.com"),
                        Subject = "Şifre Sıfırlama",
                        Body = $"Şifrenizi sıfırlamak için <a href='{resetLink}'>buraya tıklayın</a>.",
                        IsBodyHtml = true,
                    };
                    mailMessage.To.Add(email);
                    client.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderme hatası: " + ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var resetToken = await _context.PasswordResetTokens
        .FirstOrDefaultAsync(t => t.Token == resetPasswordViewModel.Token);

            if (resetToken == null)
            {
                return BadRequest("Geçersiz veya süresi dolmuş token.");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == resetToken.Email);
            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı.");
            }

            // Yeni şifreyi hashleyerek kaydedelim
            user.PasswordHash = Argon2.Hash(resetPasswordViewModel.NewPassword);
            await _context.SaveChangesAsync();

            // Kullanılmış token'ı kaldır
            _context.PasswordResetTokens.Remove(resetToken);
            await _context.SaveChangesAsync();

            return Ok("Şifreniz başarıyla sıfırlandı.");
        }
    }
}

