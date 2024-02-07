using CleanArchitecture.Application.CQRS.UserFiles.Commands;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities;
using Mapster;
using MediatR;

namespace CleanArchitecture.Application.CQRS.UserFiles.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, HandlerResponse<UserDisplayDto>>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<HandlerResponse<UserDisplayDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var User = request.User.Adapt<User>();

            var result = await _userService.AddAsync(User, cancellationToken);
            return result.Adapt<UserDisplayDto>();
        }
    }
}
