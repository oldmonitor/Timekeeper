using System.Collections.Generic;
using System.Threading.Tasks;
using Timekeeping.Data.Repository.Core;
using Timekeeping.Entity.Entities;

namespace Timekeeping.Data.Repository.TeamManagement
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}