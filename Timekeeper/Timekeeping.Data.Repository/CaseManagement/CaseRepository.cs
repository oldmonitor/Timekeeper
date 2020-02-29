using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timekeeping.Entity.Entities;
using System.Threading.Tasks;

namespace Timekeeping.Data.Repository
{
    public class CaseRepository : ICaseRepository
    {
        private readonly TimekeepingContext _timekeepingContext;

        public CaseRepository(TimekeepingContext timekeepingContext)
        {
            this._timekeepingContext = timekeepingContext;
        }

        public async Task<IEnumerable<Case>> GetAllCasesAsync()
        {
            return await _timekeepingContext.Cases.ToListAsync(); ;
        }


        public bool SaveAll()
        {
            return this._timekeepingContext.SaveChanges() > 0;
        }
    }
}
