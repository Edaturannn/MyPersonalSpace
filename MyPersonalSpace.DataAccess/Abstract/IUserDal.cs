using System;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.DataAccess.Abstract
{
	public interface IUserDal : IGenericDal<User>
	{
        Task<bool> UserExistsAsync(string username);
 
        Task<string?> GetPasswordHashAsync(string username);
        User? GetUserByUsername(string username);
    }
}

