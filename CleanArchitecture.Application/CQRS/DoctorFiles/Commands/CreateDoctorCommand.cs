using CleanArchitecture.Application.Dtos;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorFiles.Commands
{
    public class CreateDoctorCommand : IRequest<HandlerResponse<DoctorDisplayDto>>
    {
        public DoctorCreateDto Doctor { get; }

        public CreateDoctorCommand(DoctorCreateDto doctor)
        {
            this.Doctor = doctor;
        }
    }
}
