using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Timekeeping.Entity.Entities;

namespace Timekeeping.Data.Repository.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected readonly TimekeepingContext _context;
        public BaseRepository(TimekeepingContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
