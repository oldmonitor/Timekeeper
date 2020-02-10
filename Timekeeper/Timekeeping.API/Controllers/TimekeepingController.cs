using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timekeeping.Data.Repository;
using Timekeeping.Entity.Entities;

namespace Timekeeping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimekeepingController : ControllerBase
    {
        private ICaseRepository _caseRepository;
        public TimekeepingController(ICaseRepository caseRepository)
        {
            this._caseRepository = caseRepository;
        }

        public TimekeepingContext Context { get; }

        [HttpGet]
        public async Task<IActionResult> Cases()
        {
            var result = await _caseRepository.GetAllCasesAsync().ConfigureAwait(false);
            return Ok(result);
        }
    }


}