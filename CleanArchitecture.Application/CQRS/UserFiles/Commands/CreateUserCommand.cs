using MediatR;
using CleanArchitecture.Application.Dtos;

namespace CleanArchitecture.Application.CQRS.UserFiles.Commands
{
    public class CreateUserCommand : IRequest<HandlerResponse<UserDisplayDto>>
    {
        public UserCreateDto User { get; }

        public CreateUserCommand(UserCreateDto user)
        {
            this.User = user;
        }
    }
}