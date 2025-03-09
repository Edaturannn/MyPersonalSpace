using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPersonalSpace.DataAccess.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPersonalSpace.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StatisticalAnalysisController : Controller
    {
        private readonly Context _context;
        public StatisticalAnalysisController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Statistical1()
        {
            var values = _context.Posts.Count().ToString();
            return Ok(values);
        }
    }
}

