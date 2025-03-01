using System;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.DataAccess.Concrete;
using MyPersonalSpace.DataAccess.Repositories;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.DataAccess.EntityFramework
{
	public class EFTagDal : GenericRepository<Tag>, ITagDal
	{
		public EFTagDal(Context context) : base(context)
		{

		}
    }
}

