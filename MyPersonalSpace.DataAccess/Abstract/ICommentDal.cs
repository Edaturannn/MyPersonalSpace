using System;
using MyPersonalSpace.Dtos.Dtos.CommentDtos;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.DataAccess.Abstract
{
	public interface ICommentDal : IGenericDal<Comment>
	{
        Task<List<Comment>> GetCommentsByBlogId(int postId);
    }
}

