using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.Dtos.Dtos.PostTagDtos;
using MyPersonalSpace.Dtos.Dtos.TagDtos;
using MyPersonalSpace.Entities.Concrete;
namespace MyPersonalSpace.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        public TagsController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateTagDto createTagDto)
        {
            var mapper = _mapper.Map<Tag>(createTagDto);
            await _tagService.TAddAsync(mapper);
            return Ok("Başarılı Bir Şekilde Eklendi...");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _tagService.TDeleteAsync(id);
            return Ok("Başarılı Bir Şekilde Silindi...");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _tagService.TGetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var values = await _tagService.TGetByIdAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateTagDto updateTagDto)
        {
            var mapper = _mapper.Map<Tag>(updateTagDto);
            await _tagService.TUpdateAsync(mapper);
            return Ok("Başarılı Bir Şekilde Güncellendi...");
        }
    }
}