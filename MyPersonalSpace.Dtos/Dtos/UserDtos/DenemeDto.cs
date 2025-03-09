using System;
namespace MyPersonalSpace.Dtos.Dtos.UserDtos
{
	public class DenemeDto
	{
        public int UserId { get; set; }
        //public int Username { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        //public IFormFile? ProfileImgFile { get; set; } // Yeni dosya alanı
        public string? Bio { get; set; }
        public string? Skills { get; set; }
        public string? Experience { get; set; }

        public string? Profile_Img;

        public string? ProfileImgEncoded;
    }
}

