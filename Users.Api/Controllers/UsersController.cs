using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Users.Api.Data.Services;
using Users.Api.DTOs;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUser()
        {
            var users = await _usersService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _usersService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
