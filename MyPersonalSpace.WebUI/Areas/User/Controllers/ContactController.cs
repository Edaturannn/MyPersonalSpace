using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Dtos.Dtos.AboutDtos;
using MyPersonalSpace.Dtos.Dtos.CommentDtos;
using MyPersonalSpace.Dtos.Dtos.ContactDtos;
using Newtonsoft.Json;

namespace MyPersonalSpace.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7005/api/Contacts", stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return Ok("Hatalı");
            }
            return RedirectToAction("Index", "Home", new { area = "User" });
        }
    }
}

