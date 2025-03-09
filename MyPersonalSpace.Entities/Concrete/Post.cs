using System;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalSpace.Entities.Concrete
{
	public class Post
	{
		[Key]
		public int PostId { get; set; }


		public string Title { get; set; }

		public string Content { get; set; }

		public string Img { get; set; }

		public DateTime? CreatedAt { get; set; } = DateTime.Now;

		public int UserId { get; set; }
		public User User { get; set; }

		public List<Comment> Comments { get; set; }
		public List<PostTag> PostTags { get; set; }
	}
}

