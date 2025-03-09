using System;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalSpace.Entities.Concrete
{
	public class Tag
	{
		[Key]
		public int TagId { get; set; }


		public string Name { get; set; }

		public List<PostTag> PostTags { get; set; }
	}
}

