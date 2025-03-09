using System;
namespace MyPersonalSpace.Dtos.Dtos.PostDtos
{
	public class UpdatePostDto
	{
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Img { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
    }
}

