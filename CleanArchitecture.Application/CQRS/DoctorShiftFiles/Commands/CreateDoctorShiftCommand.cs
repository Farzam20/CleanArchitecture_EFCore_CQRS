using CleanArchitecture.Application.Dtos;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorShiftFiles.Commands
{
    public class CreateDoctorShiftCommand : IRequest<HandlerResponse<DoctorShiftDisplayDto>>
    {
        public DoctorShiftCreateDto DoctorShift { get; }

        public CreateDoctorShiftCommand(DoctorShiftCreateDto doctorShift)
        {
            this.DoctorShift = doctorShift;
        }
    }
}
