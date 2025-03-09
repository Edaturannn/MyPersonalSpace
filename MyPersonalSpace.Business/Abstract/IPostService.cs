using System;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.Business.Abstract
{
	public interface IPostService : IGenericService<Post>
	{
        Task<IEnumerable<Post>> TOrderByListPostsAsync();
    }
}

