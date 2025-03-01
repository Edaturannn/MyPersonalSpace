using System;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.Dtos.Dtos.CommentDtos;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.Business.Concrete
{
	public class CommentManager : ICommentService
	{
		private readonly ICommentDal _commentDal;
		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}

        public async Task<List<Comment>> TGetCommentsByBlogId(int blogId)
        {
            return await _commentDal.GetCommentsByBlogId(blogId);
        }

        public async Task TAddAsync(Comment t)
        {
            await _commentDal.AddAsync(t);
        }

        public async Task TDeleteAsync(int id)
        {
            await _commentDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<Comment>> TGetAllAsync()
        {
            return await _commentDal.GetAllAsync();
        }

        public async Task<Comment> TGetByIdAsync(int id)
        {
            return await _commentDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Comment t)
        {
            await _commentDal.UpdateAsync(t);
        }
    }
}

