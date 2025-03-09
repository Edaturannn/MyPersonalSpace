using System;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Dtos.Dtos.AboutDtos;
using MyPersonalSpace.Dtos.Dtos.PostDtos;
using Newtonsoft.Json;

namespace MyPersonalSpace.WebUI.Areas.User.ViewComponents.User
{
	public class HeaderViewComponentLayout : ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;
        public HeaderViewComponentLayout(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7005/api/Abouts");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

