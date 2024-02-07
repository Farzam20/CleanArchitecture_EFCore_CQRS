using CleanArchitecture.Application.Dtos;
using MediatR;

namespace CleanArchitecture.Application.CQRS.UserFiles.Commands
{
    public class UpdateUserCommand : IRequest<HandlerResponse<UserDisplayDto>>
    {
        public UserCreateDto User { get; }

        public UpdateUserCommand(UserCreateDto user)
        {
            User = user;
        }
    }
}
