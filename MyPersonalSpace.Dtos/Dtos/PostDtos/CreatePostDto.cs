using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalSpace.Dtos.Dtos.PostDtos
{
    public class CreatePostDto
    {
        public string Title { get; set; }

        public string Content { get; set; }


        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
    }
}

