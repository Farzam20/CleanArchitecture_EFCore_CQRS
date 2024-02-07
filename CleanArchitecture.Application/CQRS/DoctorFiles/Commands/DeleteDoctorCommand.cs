using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorFiles.Commands
{
    public class DeleteDoctorCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeleteDoctorCommand(int id)
        {
            this.Id = id;
        }
    }
}
