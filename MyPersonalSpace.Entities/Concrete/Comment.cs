using System;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalSpace.Entities.Concrete
{
	public class Comment
	{
		[Key]
		public int CommentId { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }


		public DateTime CreatedAt { get; set; } = DateTime.Now;


        public int UserId { get; set; }
		public User User { get; set; }

		public int PostId { get; set; }
		public Post Post { get; set; }
	}
}

