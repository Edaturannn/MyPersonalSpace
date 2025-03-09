using System;
using Microsoft.EntityFrameworkCore;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.DataAccess.Concrete;
using MyPersonalSpace.DataAccess.Repositories;
using MyPersonalSpace.Dtos.Dtos.PostDtos;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.DataAccess.EntityFramework
{
	public class EFPostDal : GenericRepository<Post>, IPostDal
	{
		public EFPostDal(Context context) : base(context)
		{

		}

        public async Task<IEnumerable<Post>> OrderByListPostsAsync()
        {
            Context context = new Context();
            return await context.Posts.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }
    }
}

