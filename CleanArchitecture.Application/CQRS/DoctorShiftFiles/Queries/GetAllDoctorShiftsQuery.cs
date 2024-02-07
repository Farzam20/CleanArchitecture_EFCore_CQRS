using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Domain.Entities.Hospital;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorShiftFiles.Queries
{
    public class GetAllDoctorShiftsQuery : IRequest<HandlerResponse<List<DoctorShiftDisplayDto>>>
    {
        public DateTime? Date { get; }
        public ShiftStatus? ShiftStatus { get; }
        public GetAllDoctorShiftsQuery(DateTime? date, ShiftStatus? shiftStatus)
        {
            this.Date = date;
            ShiftStatus = shiftStatus;
        }
    }
}
