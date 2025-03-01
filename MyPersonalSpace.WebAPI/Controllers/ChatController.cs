using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPersonalSpace.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly OllamaService _ollamaService;

        public ChatController(OllamaService ollamaService)
        {
            _ollamaService = ollamaService;
        }

        [HttpPost]
        public async Task<IActionResult> AskAI([FromBody] ChatRequest request)
        {
            string response = await _ollamaService.GetAIResponse(request.Message);
            return Ok(new { reply = response });
        }
    }
    public class ChatRequest
    {
        public string Message { get; set; }
    }
}

