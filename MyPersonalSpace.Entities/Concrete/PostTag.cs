using System;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalSpace.Entities.Concrete
{
	public class PostTag
	{
		[Key]
		public int PostId { get; set; }
		public Post Post { get; set; }

		public int TagId { get; set; }
		public Tag Tag { get; set; }
	}
}

