using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Api.DTOs;
using Users.Api.Models;

namespace Users.Api.Data.Services
{
    public class UsersService:IUsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        private static UserDto userToDto(User user) => new UserDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Age = user.Age,
            PersonalNumber = user.PersonalNumber
        };

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _context.Users.Select(x => userToDto(x)).ToListAsync();
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return userToDto(user);
        }
    }
}
