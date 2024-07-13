
using EdnasLibrary.Application.Commands.User;
using EdnasLibrary.Application.Responses;
using EdnasLibrary.Application.Responses.User;
using EdnasLibrary.Core.Contracts;
using EdnasLibrary.Core.Dtos;
using EdnasLibrary.Core.Entities;
using EdnasLibrary.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace EdnasLibrary.Application.Handlers.User
{
    public class AddUserHandler(IUserRepository userRepository) : IRequestHandler<AddUserCommand, AddUserResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<AddUserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!Enum.IsDefined(typeof(RoleEnum), request.Role))
                {
                    throw new Exception("Role inválida");
                }

                var user = new AddUserDto
                {
                    CompleteName = request.CompleteName,
                    Email = request.Email,
                    Password = request.Password,
                    Role = request.Role,
                };

                var result = await _userRepository.AddUser(user);
                
                return new AddUserResponse(result.Id, result.CompleteName, result.Email, result.Role, result.CreatedAt);
            }
            catch (Exception ex)
            {
                throw new ErrorResponse(StatusCodes.Status400BadRequest, "Não foi possível cadastrar o usuário.", ex.Message);
            }
        }
    }
}
