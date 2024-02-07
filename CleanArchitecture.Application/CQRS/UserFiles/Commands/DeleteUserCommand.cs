using MediatR;

namespace CleanArchitecture.Application.CQRS.UserFiles.Commands
{
    public class DeleteUserCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
