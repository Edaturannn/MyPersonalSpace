using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Dtos.Dtos.AboutDtos;
using MyPersonalSpace.Dtos.Dtos.PostDtos;
using MyPersonalSpace.Dtos.Dtos.UserDtos;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPersonalSpace.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password, string rolename)
        {
            var client = _httpClientFactory.CreateClient();
            string myPersonalSpaceCookie = Request.Cookies["MyPersonalSpace"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", myPersonalSpaceCookie);

            //Kullanıcı bilgilerini JSON olarak hazırlıyoruz.
            var loginData = new
            {
                Username = username,
                Rolename = rolename,
                Password = password
            };
            //JSON verisini StringContent olarak hazırlıyoruz.
            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            //POST isteği gönderiyoruz.
            var authResponse = await client.PostAsync("https://localhost:7005/api/Auth/Login", content);

            if(!authResponse.IsSuccessStatusCode)
            {
                return Ok("Hatalı Giriş Yaptınız!!!");
            }

            //Dönen JSON verisini deserialization yapıyoruz.
            var loginResult = await authResponse.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<LoginResultDto?>(loginResult);

            if(values == null)
            {
                return Ok("Hatalı Giriş Yaptınız!!!");
            }

            //Token'ı tarayıcıya çerez olarak ekliyoruz.
            Response.Cookies.Append("MyPersonalSpace", values.Token, new CookieOptions
            {
                HttpOnly = true, //XSS saldırılarına karşı koruma.
                Secure = true, //HTTPS üzerinden gönderim
                SameSite = SameSiteMode.Strict, //Çerezin sadece aynı site üzerinden çalışması
                Expires = DateTimeOffset.UtcNow.AddDays(7) //Çerezin geçerlilik süresi
            });

            //Başarılı giriş sonrası yönlendirme yapıyoruz.
            if(values.RoleName == "Admin")
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            if(values.RoleName == "User")
            {
                return RedirectToAction("Index", "Home", new { area = "User" });
            }
            return Ok("Rol Alanınız Boş Tekrar Giriniz...");
        }
    }
}

