using EdnasLibrary.Core.Contracts;
using EdnasLibrary.Core.Dtos;
using EdnasLibrary.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EdnasLibrary.Infra.Repositories
{
    public class AuthJwtRepository(IConfiguration config, IHttpContextAccessor httpContextAccessor) : IAuthJwtRepository
    {        
        private readonly IConfiguration _config = config;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<string> GenerateToken(JwtTokenUser jwtTokenUser)
        {
            // Configurando Key JWT
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            // Selecionando as claims que serão adicionadas ao token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwtTokenUser.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, jwtTokenUser.Email ?? ""),
                new Claim(ClaimTypes.Role, jwtTokenUser.Role.ToString())
            };

            // Configurando o token
            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_config["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<JwtAuth> AuthJwtLogin(JwtTokenUser jwtTokenUser)
        {
            var token = await GenerateToken(jwtTokenUser);
            return new JwtAuth
            {
                TokenType = "Bearer",
                AccessToken = token,
                ExpiresIn = Convert.ToInt32(_config["JwtSettings:DurationInMinutes"])                
            };
        }

        public async Task GetUserClaimsToken()
        {
            var tokenString = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ").Last();

            // Decodificar o token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(tokenString);

            // Obter informações do usuário a partir das claims
            var userId = token.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
            var email = token.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Email).Value;

            Console.WriteLine($"email {email}");


            // Agora você pode usar as informações do usuário como necessário
            //return email;
        }
    }
}
