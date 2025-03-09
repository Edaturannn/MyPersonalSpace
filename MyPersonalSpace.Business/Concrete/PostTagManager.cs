using System;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.Business.Concrete
{
	public class PostTagManager : IPostTagService
	{
		private readonly IPostTagDal _postTagDal;
		public PostTagManager(IPostTagDal postTagDal)
		{
			_postTagDal = postTagDal;
		}

        public async Task TAddAsync(PostTag t)
        {
            await _postTagDal.AddAsync(t);
        }

        public async Task TDeleteAsync(int id)
        {
            await _postTagDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<PostTag>> TGetAllAsync()
        {
            return await _postTagDal.GetAllAsync();
        }

        public async Task<PostTag> TGetByIdAsync(int id)
        {
            return await _postTagDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(PostTag t)
        {
            await _postTagDal.UpdateAsync(t);
        }
    }
}

