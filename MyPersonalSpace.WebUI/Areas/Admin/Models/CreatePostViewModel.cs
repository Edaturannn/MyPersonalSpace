using System;
using System.Reflection;

namespace MyPersonalSpace.WebUI.Areas.Admin.Models
{
    public class CreatePostViewModel //Formdan alırken bu modeli kullandık.
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public IFormFile? ImgFile { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
    }


    public class CreatePostViewModelAPIRequest //API istek atarken bu modeli kullandık.
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string? ImgEncoded { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
    }
}

