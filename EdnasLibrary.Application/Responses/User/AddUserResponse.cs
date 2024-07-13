using EdnasLibrary.Core.Entities;
using EdnasLibrary.Core.Enums;
using MediatR;

namespace EdnasLibrary.Application.Responses.User
{
    public record AddUserResponse(Guid Id, string CompleteName, string Email, RoleEnum Role, DateTime CreatedAt) : INotification
    {
        public static implicit operator AddUserResponse(ApiUser user)
        {
            return new AddUserResponse(user);
        }
    }
}
