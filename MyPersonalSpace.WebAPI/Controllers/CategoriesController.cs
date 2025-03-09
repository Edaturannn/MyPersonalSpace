using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.Dtos.Dtos.CategoryDtos;
using MyPersonalSpace.Entities.Concrete;
namespace MyPersonalSpace.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateCategoryDto createCategoryDto)
        {
            var mapper = _mapper.Map<Category>(createCategoryDto);
            await _categoryService.TAddAsync(mapper);
            return Ok("Başarılı Bir Şekilde Eklendi...");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _categoryService.TDeleteAsync(id);
            return Ok("Başarılı Bir Şekilde Silindi...");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _categoryService.TGetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var values = await _categoryService.TGetByIdAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            var mapper = _mapper.Map<Category>(updateCategoryDto);
            await _categoryService.TUpdateAsync(mapper);
            return Ok("Başarılı Bir Şekilde Güncellendi...");
        }
    }
}

