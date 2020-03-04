using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Timekeeper.Model.TeamManagement;
using Timekeeping.Data.Repository.TeamManagement;

namespace Timekeeping.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public UserController(IUserRepository repo, IConfiguration config, IMapper mapper)
        {
            _config = config;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers().ConfigureAwait(false);

            var usersToReturn = _mapper.Map<IEnumerable<UserListRecordModel>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id).ConfigureAwait(false);

            var userToReturn = _mapper.Map<UserProfileDetailModel>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserProfileUpdateModel userForUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id).ConfigureAwait(false);

            _mapper.Map(userForUpdateDto, userFromRepo);

            if (await _repo.SaveAll().ConfigureAwait(false))
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");
        }

    }
}