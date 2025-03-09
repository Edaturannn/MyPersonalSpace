using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.DataAccess.Concrete;
using MyPersonalSpace.Dtos.Dtos.TagDtos;
using MyPersonalSpace.Dtos.Dtos.UserDtos;
using MyPersonalSpace.Entities.Concrete;
namespace MyPersonalSpace.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly Context _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(Context context, IUserService userService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> UserPage()
        {
            // Kullanıcı kimliği kontrolü
            if (string.IsNullOrEmpty(User.Identity?.Name))
            {
                return Unauthorized("Kullanıcı oturumu bulunamadı.");
            }

            // sessionId'nin GUID formatına çevrilmesi
            if (!Guid.TryParse(User.Identity.Name, out Guid sessionId))
            {
                return BadRequest("Geçersiz session ID formatı.");
            }

            // Session bilgisini veritabanından çekme
            var session = await _context.Sessions.FindAsync(sessionId);
            if (session == null)
            {
                return Unauthorized("Geçersiz oturum kimliği.");
            }

            // Kullanıcı adı alınıyor
            var username = session.Username;

            // Kullanıcı bilgisi çekiliyor
            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            return Ok(user);

        }



        [HttpPost]
        public async Task<IActionResult> AddAsync(DenemeDto denemeDto)
        {
            var mapper = _mapper.Map<User>(denemeDto);
            await _userService.TAddAsync(mapper);
            return Ok("Başarılı Bir Şekilde Eklendi...");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userService.TDeleteAsync(id);
            return Ok("Başarılı Bir Şekilde Silindi...");
        }
        [HttpGet("GetListAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _userService.TGetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var values = await _userService.TGetByIdAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(DenemeDto denemeDto)
        {
            var mapper = _mapper.Map<User>(denemeDto);
            await _userService.TUpdateAsync(mapper);
            return Ok("Başarılı Bir Şekilde Güncellendi...");
        }
    }
}

