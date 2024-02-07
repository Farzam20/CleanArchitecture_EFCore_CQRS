using CleanArchitecture.Application.Dtos;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorFiles.Commands
{
    public class UpdateDoctorCommand : IRequest<HandlerResponse<DoctorDisplayDto>>
    {
        public DoctorCreateDto Doctor { get; }

        public UpdateDoctorCommand(DoctorCreateDto doctor)
        {
            this.Doctor = doctor;
        }
    }
}
