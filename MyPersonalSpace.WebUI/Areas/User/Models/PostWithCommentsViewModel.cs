using System;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.WebUI.Areas.User.Models
{
	public class PostWithCommentsViewModel
	{
        public Post Post { get; set; }  // Post modelini saklar
        public List<Comment> Comments { get; set; }  // Yorumları saklar
    }
}

