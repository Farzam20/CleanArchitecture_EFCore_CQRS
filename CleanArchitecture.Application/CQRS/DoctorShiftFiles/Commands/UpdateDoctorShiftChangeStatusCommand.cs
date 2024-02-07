using CleanArchitecture.Application.Dtos;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorShiftFiles.Commands
{
    public class UpdateDoctorShiftChangeStatusCommand : IRequest<HandlerResponse<DoctorShiftDisplayDto>>
    {
        public DoctorShiftChangeStatusDto DoctorShiftChangeStatus { get; }

        public UpdateDoctorShiftChangeStatusCommand(DoctorShiftChangeStatusDto doctorShiftChangeStatus)
        {
            this.DoctorShiftChangeStatus = doctorShiftChangeStatus;
        }
    }
}
