using Users.Api.DTOs;
using Users.Api.Models;

namespace Users.Api.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDisplayDto>> GetAll();
        Task<UserDisplayDto> GetById(int id);
        Task<UserDto> Update(int id, UserDto userDto);

        Task Delete(int id);
        Task<User> Add(UserDto userDto);

    }
}