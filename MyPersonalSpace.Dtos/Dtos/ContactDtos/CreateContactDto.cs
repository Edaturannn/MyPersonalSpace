using System;
namespace MyPersonalSpace.Dtos.Dtos.ContactDtos
{
	public class CreateContactDto
	{

        public string Name { get; set; }


        public string Email { get; set; }


        public string Subject { get; set; }


        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

