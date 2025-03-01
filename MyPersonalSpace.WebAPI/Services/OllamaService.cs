using System;
using Newtonsoft.Json;
using System.Text;

namespace MyPersonalSpace.WebAPI.Services
{
	public class OllamaService
	{
        private readonly HttpClient _httpClient;

        public OllamaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAIResponse(string prompt)
        {
            var requestData = new
            {
                model = "mistral",  // Ollama'nın çalıştıracağı model
                prompt = prompt,
                stream = false
            };

            var jsonContent = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:11434/api/generate", content);
            var responseString = await response.Content.ReadAsStringAsync();

            dynamic responseObject = JsonConvert.DeserializeObject(responseString);
            return responseObject.response;
        }
    }
}

