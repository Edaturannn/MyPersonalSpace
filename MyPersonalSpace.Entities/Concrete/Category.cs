using System;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalSpace.Entities.Concrete
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }


		public string Name { get; set; }

		public List<Post> Posts { get; set; }
    }
}

