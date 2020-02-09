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
        private ILogger<TimekeepingController> _logger;
        public TimekeepingController(ICaseRepository caseRepository, ILogger<TimekeepingController> logger)
        {
            this._caseRepository = caseRepository;
            this._logger = logger;
        }

        public TimekeepingContext Context { get; }

        [HttpGet]
        public IActionResult Cases()
        {
            var result = this._caseRepository.GetAllCases();
            _logger.LogInformation(message: "information test");
            return Ok(result);
        }
    }


}