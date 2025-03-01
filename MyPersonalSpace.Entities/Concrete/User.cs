using System;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalSpace.Entities.Concrete
{
	public class User
	{
		[Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public string? RoleName { get; set; } 




        // Users Sayfasında Profile Sayfasında boş olan alanlrı içini dolduracak.
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Profile_Img { get; set; }
        public string? Bio { get; set; }
        public string? Skills { get; set; }
        public string? Experience { get; set; }
        // Users Sayfasında Profile Sayfasında boş olan alanlrı içini dolduracak.

        public List<Post> Posts { get; set; }
		public List<Comment> Comments { get; set; }

	}
}

