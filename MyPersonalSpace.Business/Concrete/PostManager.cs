using System;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.Business.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;
        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }
        public async Task TAddAsync(Post t)
        {
            await _postDal.AddAsync(t);
        }

        public async Task TDeleteAsync(int id)
        {
            await _postDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<Post>> TGetAllAsync()
        {
            return await _postDal.GetAllAsync();
        }

        public async Task<Post> TGetByIdAsync(int id)
        {
            return await _postDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Post>> TOrderByListPostsAsync()
        {
            return await _postDal.OrderByListPostsAsync();
        }

        public async Task TUpdateAsync(Post t)
        {
            await _postDal.UpdateAsync(t);
        }
    }
}

