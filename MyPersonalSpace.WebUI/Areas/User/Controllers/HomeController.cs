using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Dtos.Dtos.PostDtos;
using Newtonsoft.Json;
using MyPersonalSpace.Entities.Concrete;
using MyPersonalSpace.Dtos.Dtos.UserDtos;
using MyPersonalSpace.WebUI.Areas.User.Models;

namespace MyPersonalSpace.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7005/api/Posts");

            string myPersonalSpaceCookie = Request.Cookies["MyPersonalSpace"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", myPersonalSpaceCookie);
            var authResponse = await client.GetAsync("https://localhost:7005/api/Users");


            if (!authResponse.IsSuccessStatusCode)
            {
                return Unauthorized("Giriş yapmadan bu sayfaya ulaşamazsınız...");
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPostDto>>(jsonData);

                var authData = await authResponse.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<MyPersonalSpace.Entities.Concrete.User>(authData);
                ViewBag.UserName = user;
                ViewBag.UserID = user;

                int totalPosts = values.Count;
                var pagedPosts = values.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = (int)Math.Ceiling((double)totalPosts / pageSize);

                return View(pagedPosts);
            }
            return View();
        }
        public async Task<IActionResult> PostDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Post detaylarını çek
            var responseMessage = await client.GetAsync($"https://localhost:7005/api/Posts/{id}");
            // Posta ait yorumları çek
            var responseMessage2 = await client.GetAsync($"https://localhost:7005/api/Comments/{id}");

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                // Post içeriğini JSON olarak al
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var post = JsonConvert.DeserializeObject<Post>(jsonData); // Tek nesne

                // Yorumları JSON olarak al
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<Comment>>(jsonData2); // Liste olarak deserialize et

                // ViewModel oluştur
                var viewModel = new PostWithCommentsViewModel
                {
                    Post = post,
                    Comments = comments
                };

                return View(viewModel);
            }

            return View();
        }
    }
}

