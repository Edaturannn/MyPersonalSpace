using System;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalSpace.Entities.Concrete
{
	public class Contact
	{
        [Key]
        public int ContactId { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }


        public string Subject { get; set; }


        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

