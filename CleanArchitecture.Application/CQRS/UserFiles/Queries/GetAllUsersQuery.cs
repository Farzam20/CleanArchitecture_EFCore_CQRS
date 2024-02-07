using MediatR;
using CleanArchitecture.Application.Dtos;

namespace CleanArchitecture.Application.CQRS.UserFiles.Queries
{
    public class GetAllUsersQuery : IRequest<HandlerResponse<List<UserDisplayDto>>>
    {
        public GetAllUsersQuery()
        {
        }
    }
}
