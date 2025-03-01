using System;
using MyPersonalSpace.Dtos.Dtos.PostDtos;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.DataAccess.Abstract
{
	public interface IPostDal : IGenericDal<Post>
	{
		Task<IEnumerable<Post>> OrderByListPostsAsync();
    }
}

