using System;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.DataAccess.Concrete;
using MyPersonalSpace.DataAccess.Repositories;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.DataAccess.EntityFramework
{
	public class EFPostTagDal : GenericRepository<PostTag>, IPostTagDal
    {
		public EFPostTagDal(Context context) : base(context)
        {

        }
    }
}

