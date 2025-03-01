using System;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.DataAccess.Concrete;
using MyPersonalSpace.DataAccess.Repositories;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.DataAccess.EntityFramework
{
	public class EFAboutDal : GenericRepository<About>, IAboutDal
	{
		public EFAboutDal(Context context) : base(context)
		{

		}
    }
}

