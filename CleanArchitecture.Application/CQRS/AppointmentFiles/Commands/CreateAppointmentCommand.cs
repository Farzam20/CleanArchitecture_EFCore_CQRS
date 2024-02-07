using CleanArchitecture.Application.Dtos;
using MediatR;

namespace CleanArchitecture.Application.CQRS.AppointmentFiles.Commands
{
    public class CreateAppointmentCommand : IRequest<HandlerResponse<AppointmentDisplayDto>>
    {
        public AppointmentCreateDto Appointment { get; }
        public CreateAppointmentCommand(AppointmentCreateDto appointment)
        {
            this.Appointment = appointment;
        }
    }
}
