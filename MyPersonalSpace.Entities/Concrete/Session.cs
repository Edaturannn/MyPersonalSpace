using System;
namespace MyPersonalSpace.Entities.Concrete
{
	public class Session
	{
       public Guid SessionId { get; set; }
       public string Username { get; set; }
       public DateTime CreatedAt { get; set; }
       public DateTime ExpiresAt { get; set; }
    }
}

