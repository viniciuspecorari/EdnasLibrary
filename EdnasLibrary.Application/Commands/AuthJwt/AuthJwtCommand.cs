using EdnasLibrary.Application.Responses.AuthJwt;
using MediatR;

namespace EdnasLibrary.Application.Commands.AuthJwt
{
    public class AuthJwtCommand : IRequest<AuthJwtResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
