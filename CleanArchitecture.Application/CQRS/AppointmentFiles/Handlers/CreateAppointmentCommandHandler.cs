using CleanArchitecture.Application.CQRS.AppointmentFiles.Commands;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.CQRS.AppointmentFiles.Handlers
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, HandlerResponse<AppointmentDisplayDto>>
    {
        private readonly IBaseService<Appointment> _service;

        public CreateAppointmentCommandHandler(IBaseService<Appointment> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<AppointmentDisplayDto>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new Appointment()
            {
                DoctorShiftId = request.Appointment.DoctorShiftId
            };

            if (request.Appointment.PatientId.HasValue)
                appointment.PatientId = request.Appointment.PatientId.Value;
            else
            {
                appointment.Patient = new Patient()
                {
                    FirstName = request.Appointment.FirstName,
                    LastName = request.Appointment.LastName,
                    NationalCode = request.Appointment.NationalCode,
                    Mobile = request.Appointment.Mobile
                };
            }

            var previousVisit = await _service.GetAll(x => x.DoctorShiftId == request.Appointment.DoctorShiftId).FirstOrDefaultAsync();
            appointment.VisitNumber = previousVisit == null ? 1 : (previousVisit.VisitNumber + 1);
            appointment.TrackingCode = Guid.NewGuid().ToString();

            var result = await _service.AddAsync(appointment, cancellationToken);

            return result.Adapt<AppointmentDisplayDto>();
        }
    }
}
