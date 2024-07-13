using EdnasLibrary.Application.Commands.AuthJwt;
using EdnasLibrary.Application.Responses;
using EdnasLibrary.Application.Responses.AuthJwt;
using EdnasLibrary.Core.Contracts;
using EdnasLibrary.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EdnasLibrary.Application.Handlers.AuthJwt
{
    public class AuthJwtHandler(IUserRepository userRepository) : IRequestHandler<AuthJwtCommand, AuthJwtResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<AuthJwtResponse> Handle(AuthJwtCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newLogin = new LoginUserDto
                {
                    Email = request.Email,
                    Password = request.Password,
                };


                var login = await _userRepository.LoginUser(newLogin);


                if (login is null)
                {
                    throw new Exception("Login ou senha inválidos.");
                }

                return new AuthJwtResponse
                {
                    TokenType = login.TokenType,
                    AccessToken = login.AccessToken,
                    ExpiresIn = login.ExpiresIn,                    
                };
            }
            catch (Exception ex)
            {
                throw new ErrorResponse(StatusCodes.Status400BadRequest, "Ação não concluída", ex.Message);
            }
        }
    }
}
