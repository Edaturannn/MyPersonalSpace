using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Dtos.Dtos.CommentDtos;
using MyPersonalSpace.Dtos.Dtos.PostDtos;
using MyPersonalSpace.Entities.Concrete;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPersonalSpace.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddComment(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            string myPersonalSpaceCookie = Request.Cookies["MyPersonalSpace"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", myPersonalSpaceCookie);
            var authResponse = await client.GetAsync("https://localhost:7005/api/Users");


            if (!authResponse.IsSuccessStatusCode)
            {
                return Unauthorized("Giriş yapmadan bu sayfaya ulaşamazsınız...");
            }
            var authData = await authResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<MyPersonalSpace.Entities.Concrete.User>(authData);
            ViewBag.UserName = user;
            ViewBag.postID = Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7005/api/Comments", stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return Ok("Hatalı");
            }
            return RedirectToAction("Index", "Home", new { area = "User" });
        }
    }
}

