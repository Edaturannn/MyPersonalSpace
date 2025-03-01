using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPersonalSpace.WebUI.Controllers
{
    public class LogoutController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Cookie'yi sil
            Response.Cookies.Delete("MyPersonalSpace");

            // Kullanıcıyı giriş sayfasına yönlendir

            return RedirectToAction("Index", "Login");
        }
    }
}

