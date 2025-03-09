using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Dtos.Dtos.PostDtos;
using MyPersonalSpace.WebUI.Areas.Admin.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPersonalSpace.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PostController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7005/api/Posts");
            
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPostDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddPost()
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
            return View();
        }

        public static async Task<string> EncodeToBase64Async(IFormFile file) //DOSYAYI STRİNG İFADEYE ÇEVİRDİK.
        {
            if (file == null || file.Length == 0)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();
                return Convert.ToBase64String(fileBytes);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddPost(CreatePostViewModel createPostDto)
        {
            var client = _httpClientFactory.CreateClient();

            var request = new CreatePostViewModelAPIRequest() {
                 Title = createPostDto.Title,
                 CreatedAt = createPostDto.CreatedAt,
                 ImgEncoded = await EncodeToBase64Async(createPostDto.ImgFile), //atama işlemi yaptık. Dosyanın kendisini string e çevirdik.
                                                                                //Json formatında yollayabilimek için.
                 Content = createPostDto.Content,
                 UserId = createPostDto.UserId,
        };
           
            var jsonData = JsonConvert.SerializeObject(request); //Modeli Json formatına çevirdik.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //String yapıyor.

         


            var responseMessage = await client.PostAsync("https://localhost:7005/api/Posts", stringContent); //API istek attık.

            if(!responseMessage.IsSuccessStatusCode)
            {
                return Ok("Hatalı");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7005/api/Posts/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

