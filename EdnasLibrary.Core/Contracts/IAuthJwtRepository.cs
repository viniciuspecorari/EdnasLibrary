using EdnasLibrary.Core.Dtos;
using EdnasLibrary.Core.Models;

namespace EdnasLibrary.Core.Contracts
{
    public interface IAuthJwtRepository
    {
        Task<JwtAuth> AuthJwtLogin(JwtTokenUser jwtTokenUser);
        Task<string> GenerateToken(JwtTokenUser jwtTokenUser);
    }
}
