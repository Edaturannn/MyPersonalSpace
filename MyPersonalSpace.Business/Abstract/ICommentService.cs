using System;
using MyPersonalSpace.Dtos.Dtos.CommentDtos;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.Business.Abstract
{
	public interface ICommentService : IGenericService<Comment>
	{
        Task<List<Comment>> TGetCommentsByBlogId(int postId);
    }
}

