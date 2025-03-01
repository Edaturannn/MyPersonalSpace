using System;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.Business.Concrete
{
	public class AboutManager : IAboutService
	{
		private readonly IAboutDal _aboutDal;
		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

        public async Task TAddAsync(About t)
        {
            await _aboutDal.AddAsync(t);
        }

        public async Task TDeleteAsync(int id)
        {
            await _aboutDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<About>> TGetAllAsync()
        {
            return await _aboutDal.GetAllAsync();
        }

        public async Task<About> TGetByIdAsync(int id)
        {
            return await _aboutDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(About t)
        {
            await _aboutDal.UpdateAsync(t);
        }
    }
}

