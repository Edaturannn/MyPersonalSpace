using System;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalSpace.Entities.Concrete
{
	public class About
	{
		[Key]
		public int AboutId { get; set; }

		public string AboutMe { get; set; }

		public string Content { get; set; }

		public string Profile { get; set; }

		public string Img { get; set; }

		public string Github { get; set; }

		public string Linkedin { get; set; }
    }
}

