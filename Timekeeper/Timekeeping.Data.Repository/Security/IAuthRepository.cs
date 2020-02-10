using System.Threading.Tasks;
using Timekeeping.Entity.Entities;

namespace Timekeeping.Data.Repository.Security
{
    public interface IAuthRepository
    {
        Task<User> Login(string username, string password);
        Task<User> Register(User user, string password);
        Task<bool> UserExists(string username);
    }
}