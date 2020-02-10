using System.Collections.Generic;
using System.Threading.Tasks;
using Timekeeping.Entity.Entities;

namespace Timekeeping.Data.Repository
{
    public interface ICaseRepository
    {
        Task<IEnumerable<Case>> GetAllCasesAsync();
    }
}