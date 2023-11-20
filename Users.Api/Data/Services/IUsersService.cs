using Users.Api.DTOs;

namespace Users.Api.Data.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
    }
}