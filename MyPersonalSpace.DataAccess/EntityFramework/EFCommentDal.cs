using System;
using Microsoft.EntityFrameworkCore;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.DataAccess.Concrete;
using MyPersonalSpace.DataAccess.Repositories;
using MyPersonalSpace.Dtos.Dtos.CommentDtos;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.DataAccess.EntityFramework
{ 
	public class EFCommentDal : GenericRepository<Comment> , ICommentDal
	{
		public EFCommentDal(Context context) : base(context)
		{

		}

        public async Task<List<Comment>> GetCommentsByBlogId(int postId)
        {
            using var context = new Context();

            return await context.Comments.Where(x => x.PostId == postId).ToListAsync();
        }
    }
}

