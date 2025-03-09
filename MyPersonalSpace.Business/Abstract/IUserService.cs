using System;
using MyPersonalSpace.Dtos.Dtos.UserDtos;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.Business.Abstract
{
	public interface IUserService : IGenericService<User>
	{
        Task<bool> RegisterUserAsync(RegisterDto registerDto);

        Task<LoginResultDto?> LoginUserAsync(LoginDto loginDto);
    }
}

