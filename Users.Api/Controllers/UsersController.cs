using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using Users.Api.DTOs;
using Users.Api.Models;
using Users.Api.Services;

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

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserDto userDto)
        {
            var updatedUserDto = _usersService.Update(id, userDto);

            if (updatedUserDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser(UserDto userDto)
        {

            var user = await _usersService.Add(userDto);


            return CreatedAtAction("GetUser", new { id = user.Id }, userDto);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _usersService.Delete(id);

            return NoContent();
        }

}
}
