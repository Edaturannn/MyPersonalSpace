using System;
using Microsoft.EntityFrameworkCore;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.DataAccess.Concrete;
using MyPersonalSpace.DataAccess.Repositories;
using MyPersonalSpace.Entities.Concrete;

namespace MyPersonalSpace.DataAccess.EntityFramework
{
    public class EFUserDal : GenericRepository<User>, IUserDal
    {
        private readonly Context _context;
        public EFUserDal(Context context) : base(context)
        {
            _context = context;
        }
        public async Task<string?> GetPasswordHashAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            return user?.PasswordHash;
        }

        public User? GetUserByUsername(string username)
        {
            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();
            return user;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username);
        }
    }
}

