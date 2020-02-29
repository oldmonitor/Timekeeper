using System.Threading.Tasks;

namespace Timekeeping.Data.Repository.Core
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        Task<bool> SaveAll();
    }
}