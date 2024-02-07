using CleanArchitecture.Application.CQRS.UserFiles.Commands;
using CleanArchitecture.Application.Services.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.CQRS.UserFiles.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, HandlerResponse<bool>>
    {
        private readonly IUserService _UserService;

        public DeleteUserCommandHandler(IUserService UserService)
        {
            _UserService = UserService;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _UserService.GetByIdAsync(cancellationToken, request.Id);

            if (user == null)
                return new(false, "کاربر موردنظر یافت نشد", false);

            await _UserService.DeleteAsync(user, cancellationToken);
            return true;
        }
    }
}
