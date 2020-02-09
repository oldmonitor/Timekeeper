using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timekeeping.Entity.Entities;

namespace Timekeeping.Data.Repository
{
    public class CaseRepository : ICaseRepository
    {
        private readonly TimekeepingContext _timekeepingContext;

        public CaseRepository(TimekeepingContext timekeepingContext)
        {
            this._timekeepingContext = timekeepingContext;
        }

        public IEnumerable<Case> GetAllCases()
        {
            return _timekeepingContext.Case.ToList(); ;
        }


        public bool SaveAll()
        {
            return this._timekeepingContext.SaveChanges() > 0;
        }
    }
}
