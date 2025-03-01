using System;
using System.Diagnostics.Contracts;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.DataAccess.Concrete;
using MyPersonalSpace.DataAccess.Repositories;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.DataAccess.EntityFramework
{
	public class EFContactDal : GenericRepository<Contact>, IContactDal
    {
		public EFContactDal(Context context) : base(context)
        {

        }
    }
}

