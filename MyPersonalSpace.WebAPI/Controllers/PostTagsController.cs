using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.Dtos.Dtos.PostDtos;
using MyPersonalSpace.Dtos.Dtos.PostTagDtos;
using MyPersonalSpace.Entities.Concrete;
namespace MyPersonalSpace.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostTagsController : Controller
    {
        private readonly IPostTagService _postTagService;
        private readonly IMapper _mapper;
        public PostTagsController(IPostTagService postTagService, IMapper mapper)
        {
            _postTagService = postTagService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatePostTagDto createPostTagDto)
        {
            var mapper = _mapper.Map<PostTag>(createPostTagDto);
            await _postTagService.TAddAsync(mapper);
            return Ok("Başarılı Bir Şekilde Eklendi...");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _postTagService.TDeleteAsync(id);
            return Ok("Başarılı Bir Şekilde Silindi...");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _postTagService.TGetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var values = await _postTagService.TGetByIdAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdatePostTagDto updatePostTagDto)
        {
            var mapper = _mapper.Map<PostTag>(updatePostTagDto);
            await _postTagService.TUpdateAsync(mapper);
            return Ok("Başarılı Bir Şekilde Güncellendi...");
        }
    }
}

