using EdnasLibrary.Core.Contracts;
using EdnasLibrary.Core.Dtos;
using EdnasLibrary.Core.Entities;
using EdnasLibrary.Core.Models;
using EdnasLibrary.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EdnasLibrary.Infra.Repositories
{
    public class UserRepository(EdnasLibraryDbContext context , IAuthJwtRepository authJwt) : IUserRepository
    {
        private readonly EdnasLibraryDbContext _context = context;
        private readonly IAuthJwtRepository _AuthJwt = authJwt;
       
        public async Task<ApiUser> AddUser(AddUserDto addUserDto)
        {

            // Criando senha
            CreatePasswordHash(addUserDto.Password, out string passwordHash, out string passwordSalt);

            var user = new ApiUser
            {
                CompleteName = addUserDto.CompleteName,                
                Email = addUserDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = addUserDto.Role,
                CreatedAt = DateTime.Now,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;

        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ApiUser>> GetAllUsers()
        {
            return await _context.Users.Select(x => new ApiUser
            {
                Id = x.Id,
                CompleteName= x.CompleteName,
                Email = x.Email,
                Role = x.Role,
                CreatedAt = x.CreatedAt,

            }).ToListAsync();
        }

        public async Task<ApiUser> GetUserByEmail(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstAsync();            
        }

        public async Task<ApiUser> GetUserById(Guid Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<JwtAuth> LoginUser(LoginUserDto loginUserDto)
        {
            var user = await GetUserByEmail(loginUserDto.Email);    

            if (user == null || !VerifyPasswordHash(loginUserDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            var jwtUser = new JwtTokenUser
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
            };

            var jwtAuth = await _AuthJwt.AuthJwtLogin(jwtUser);

            return jwtAuth;
        }

        public static void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }

        public static bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
        {
            using (var hmac = new HMACSHA512(Convert.FromBase64String(storedSalt)))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(computedHash) == storedHash;
            }
        }
    }
}
