using System;
namespace MyPersonalSpace.Entities.Concrete
{
	public class PasswordResetToken
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }
		public DateTime ExpireTime { get; set; }
	}
}

