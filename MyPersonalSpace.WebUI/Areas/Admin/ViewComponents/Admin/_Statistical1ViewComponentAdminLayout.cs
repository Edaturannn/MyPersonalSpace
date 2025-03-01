using System;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Dtos.Dtos.AboutDtos;
using MyPersonalSpace.Entities.Concrete;
using MyPersonalSpace.WebUI.Areas.Admin.Models;
using Newtonsoft.Json;

namespace MyPersonalSpace.WebUI.Areas.Admin.ViewComponents.Admin
{
	public class _Statistical1ViewComponentAdminLayout : ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;
        public _Statistical1ViewComponentAdminLayout(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7005/api/StatisticalAnalysis");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData); // API sadece tek bir sayı döndürüyorsa
                return View(value);
            }
            return View();
        }
	}
}

