using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.Dtos.Dtos.CommentDtos;
using MyPersonalSpace.Dtos.Dtos.PostDtos;
using MyPersonalSpace.Entities.Concrete;
using MyPersonalSpace.WebUI.Areas.Admin.Models;

namespace MyPersonalSpace.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IMinioClient _minioClient;

        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostsController(IPostService postService, IMapper mapper, IMinioClient minioClient)
        {
            _minioClient = minioClient;
            _postService = postService;
            _mapper = mapper;
        }

        public static IFormFile DecodeFromBase64(string base64String, string fileName, string contentType) //OLUŞTURDUĞUMUZ STRİNG İFADEYİ DOSYAYA ÇEVİRDİK.
        {
            if (string.IsNullOrEmpty(base64String))
                return null;

            byte[] fileBytes = Convert.FromBase64String(base64String);
            var stream = new MemoryStream(fileBytes);
            return new FormFile(stream, 0, fileBytes.Length, "file", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreatePostViewModelAPIRequest form) //[FromBody] Json yollarken bunu yazmamız gerekiyor.
        {
            var imgFile = DecodeFromBase64(form.ImgEncoded, "a.png", "image/png"); //String ifadeyi dosyaya çevirdik.
            var newFileName = $"{Guid.NewGuid()}";

            using var ss = imgFile.OpenReadStream();
            var args = new PutObjectArgs() //CLOUD İŞLEMLERİ İÇİN KULLANDIK.
                .WithBucket("blog")
                .WithObject(newFileName) // GUID ile dosya ismini değiştirdik
                .WithStreamData(ss)
                .WithObjectSize(ss.Length)
                .WithContentType(imgFile.ContentType); // Gerçek içerik tipini kullan

            await _minioClient.PutObjectAsync(args).ConfigureAwait(false);

            var post = new Post() {
                  Title = form.Title,
                  UserId = form.UserId,
                  Content = form.Content,
                  CreatedAt = form.CreatedAt,
                  Img = newFileName, //olUŞTURDUĞUMUZ İSMİ VERİTABANINA KAYIT ETTİK.
                  //ATAMA İŞLEMİ YAPTIK.
            };
            await _postService.TAddAsync(post);
            return Ok("Başarılı Bir Şekilde Eklendi...");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _postService.TDeleteAsync(id);
            return Ok("Başarılı Bir Şekilde Silindi...");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _postService.TOrderByListPostsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var values = await _postService.TGetByIdAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdatePostDto updatePostDto)
        {
            var mapper = _mapper.Map<Post>(updatePostDto);
            await _postService.TUpdateAsync(mapper);
            return Ok("Başarılı Bir Şekilde Güncellendi...");
        }
    }
}

