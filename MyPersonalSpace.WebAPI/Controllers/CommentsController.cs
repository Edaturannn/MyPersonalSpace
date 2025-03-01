using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.Dtos.Dtos.CategoryDtos;
using MyPersonalSpace.Dtos.Dtos.CommentDtos;
using MyPersonalSpace.Entities.Concrete;
namespace MyPersonalSpace.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreateCommentDto createCommentDto)
        {
            var mapper = _mapper.Map<Comment>(createCommentDto);
            await _commentService.TAddAsync(mapper);
            return Ok("Başarılı Bir Şekilde Eklendi...");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _commentService.TDeleteAsync(id);
            return Ok("Başarılı Bir Şekilde Silindi...");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _commentService.TGetAllAsync();
            return Ok(values);
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetByIdAsync(int id)
        //{
            //var values = await _commentService.TGetByIdAsync(id);
            //return Ok(values);
        //}
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCommentDto updateCommentDto)
        {
            var mapper = _mapper.Map<Comment>(updateCommentDto);
            await _commentService.TUpdateAsync(mapper);
            return Ok("Başarılı Bir Şekilde Güncellendi...");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentsByBlogIdAsync(int id)
        {
            var values2 = await _commentService.TGetCommentsByBlogId(id);
            return Ok(values2);
        }
    }
}

