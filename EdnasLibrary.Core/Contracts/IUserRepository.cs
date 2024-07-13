using EdnasLibrary.Core.Dtos;
using EdnasLibrary.Core.Entities;
using EdnasLibrary.Core.Models;

namespace EdnasLibrary.Core.Contracts
{
    public interface IUserRepository
    {
        Task<ApiUser> AddUser(AddUserDto addUserDto);
        Task<IEnumerable<ApiUser>> GetAllUsers();
        Task<ApiUser> GetUserByEmail(string email);
        Task<ApiUser> GetUserById(Guid Id);
        Task<bool> DeleteUser(Guid id);
        Task<JwtAuth> LoginUser(LoginUserDto loginUserDto);
    }
}
