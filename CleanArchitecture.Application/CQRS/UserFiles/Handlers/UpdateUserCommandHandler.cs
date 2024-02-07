using CleanArchitecture.Application.CQRS.UserFiles.Commands;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using Mapster;
using MediatR;

namespace CleanArchitecture.Application.CQRS.UserFiles.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, HandlerResponse<UserDisplayDto>>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<HandlerResponse<UserDisplayDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var obj = await _userService.GetByIdAsync(cancellationToken, request.User.Id);

            if (obj == null)
                return new(false, ";کاربر مورد نظر یافت نشد", null);

            request.User.Adapt(obj);
            var result = await _userService.UpdateAsync(obj, cancellationToken);
            return result.Adapt<UserDisplayDto>();
        }
    }
}
