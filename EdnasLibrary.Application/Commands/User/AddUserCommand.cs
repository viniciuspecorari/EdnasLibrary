using EdnasLibrary.Application.Responses.User;
using EdnasLibrary.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EdnasLibrary.Application.Commands.User
{
    public class AddUserCommand : IRequest<AddUserResponse>
    {
        public string CompleteName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
    }
}
