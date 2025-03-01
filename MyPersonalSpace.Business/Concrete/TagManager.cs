using System;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.Business.Concrete
{
	public class TagManager : ITagService
	{
		private readonly ITagDal _tagDal;
		public TagManager(ITagDal tagDal)
		{
			_tagDal = tagDal;
		}

        public async Task TAddAsync(Tag t)
        {
            await _tagDal.AddAsync(t);
        }

        public async Task TDeleteAsync(int id)
        {
            await _tagDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<Tag>> TGetAllAsync()
        {
            return await _tagDal.GetAllAsync();
        }

        public async Task<Tag> TGetByIdAsync(int id)
        {
            return await _tagDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Tag t)
        {
            await _tagDal.UpdateAsync(t);
        }
    }
}

