using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Timekeeping.Data.Repository.Core;
using Timekeeping.Entity.Entities;

namespace Timekeeping.Data.Repository.TeamManagement
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TimekeepingContext context)
            : base(context)
        {
        }

        public async Task<User> GetUser(int id)
        {
            var user = await this._context.Users.Include(p => p.UserPhotoes).FirstOrDefaultAsync(u => u.UserId == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.UserPhotoes).ToListAsync();
            return users;
        }
    }
}
