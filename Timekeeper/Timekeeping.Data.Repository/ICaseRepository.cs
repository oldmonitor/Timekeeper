using System.Collections.Generic;
using Timekeeping.Entity.Entities;

namespace Timekeeping.Data.Repository
{
    public interface ICaseRepository
    {
        IEnumerable<Case> GetAllCases();
    }
}