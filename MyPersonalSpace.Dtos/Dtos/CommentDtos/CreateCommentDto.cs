using System;
namespace MyPersonalSpace.Dtos.Dtos.CommentDtos
{
	public class CreateCommentDto
	{
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public int PostId { get; set; }
    }
}

