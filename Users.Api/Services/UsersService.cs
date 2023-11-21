using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Users.Api.Data;
using Users.Api.DTOs;
using Users.Api.Models;

namespace Users.Api.Services
{
    public class UsersService : IUsersService
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
            PersonalNumber = user.PersonalNumber,
            UsernameId = user.UserNameId,

        };

        public async Task<IEnumerable<UserDisplayDto>> GetAll()
        {
            var user = await _context.Users.Select(x => new UserDisplayDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    PersonalNumber = x.PersonalNumber,
                    UserName = x.Username.Name,
                    PostContent = x.Posts.Select(p=> p.Content).ToList()
                }
            ).ToListAsync();

            return user;
        }

        public async Task<UserDisplayDto> GetById(int id)
        {
            var user = await _context.Users.Where(u=> u.Id == id).Select(x => new UserDisplayDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    PersonalNumber = x.PersonalNumber,
                    UserName = x.Username.Name,
                    PostContent = x.Posts.Select(p => p.Content).ToList()

            }
            ).FirstOrDefaultAsync();

            return user;
        }

        public async Task<UserDto> Update(int id, UserDto userDto)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Age = userDto.Age;
                user.PersonalNumber = userDto.PersonalNumber;
                user.UserNameId = userDto.UsernameId;

                await _context.SaveChangesAsync();
            }

            return userDto;
            }


        public async Task Delete(int id)
        {
            var user  = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
               
            }
            await _context.SaveChangesAsync();
        }

        public async Task<User> Add(UserDto userDto)
        {
            var user = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age,
                PersonalNumber = userDto.PersonalNumber,
                UserNameId = userDto.UsernameId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }


    }
}
