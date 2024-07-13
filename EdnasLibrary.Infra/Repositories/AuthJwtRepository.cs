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

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"] ?? string.Empty));
            var issuer = _config["JwtSettings:Issuer"];
            var audience = _config["JwtSettings:Audience"];

            var singinCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new[]
                {
                    new Claim(type: "UserId", jwtTokenUser.Id.ToString()),
                    new Claim(type: "Email", jwtTokenUser.Email),
                    new Claim(type: ClaimTypes.Role, jwtTokenUser.Role.ToString())
                },
                expires: DateTime.Now.AddMinutes(int.Parse(_config["JwtSettings:DurationInMinutes"])),
                signingCredentials: singinCredential
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;

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
            var userId = token.Claims.First(claim => claim.Type == "UserId").Value;
            var email = token.Claims.First(claim => claim.Type == "Email").Value;
            


            // Agora você pode usar as informações do usuário como necessário
            //return email;
        }
    }
}
