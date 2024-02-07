using MediatR;
using CleanArchitecture.Application.Dtos;

namespace CleanArchitecture.Application.CQRS.UserFiles.Queries
{
    public class GetUserQuery : IRequest<HandlerResponse<UserDisplayDto>>
    {
        public int Id { get; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}
