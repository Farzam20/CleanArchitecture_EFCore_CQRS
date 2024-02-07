using CleanArchitecture.Application.CQRS.UserFiles.Queries;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using Mapster;
using MediatR;
using CleanArchitecture.Application.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.CQRS.UserFiles.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, HandlerResponse<UserDisplayDto>>
    {
        private readonly IUserService _userService;

        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<HandlerResponse<UserDisplayDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByIdAsync(cancellationToken, request.Id);

            if (user == null)
                return new(false, "کاربر موردنظر یافت نشد", null);

            return user.Adapt<UserDisplayDto>();
        }
    }

    public class LoginQueryHandler : IRequestHandler<LoginQuery, HandlerResponse<string>>
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public LoginQueryHandler(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        public async Task<HandlerResponse<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var passwordHash = SecurityHelper.GetSha256Hash(request.Password);
            var user = await _userService.GetAll(x => x.UserName == request.UserName && x.PasswordHash == passwordHash)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
                return new(false, "کاربر موردنظر یافت نشد", null);

            return await _jwtService.Generate(user);
        }
    }
}
