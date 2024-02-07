using CleanArchitecture.Application.CQRS.UserFiles.Queries;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using Mapster;
using MediatR;

namespace CleanArchitecture.Application.CQRS.UserFiles.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, HandlerResponse<List<UserDisplayDto>>>
    {
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<HandlerResponse<List<UserDisplayDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var items = _userService.GetAll();

            return items.Adapt<List<UserDisplayDto>>();
        }
    }
}
