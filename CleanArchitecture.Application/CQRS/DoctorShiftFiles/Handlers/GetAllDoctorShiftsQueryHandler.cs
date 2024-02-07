using CleanArchitecture.Application.CQRS.DoctorShiftFiles.Queries;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.CQRS.DoctorShiftFiles.Handlers
{
    public class GetAllDoctorShiftsQueryHandler : IRequestHandler<GetAllDoctorShiftsQuery, HandlerResponse<List<DoctorShiftDisplayDto>>>
    {
        private readonly IBaseService<DoctorShift> _service;

        public GetAllDoctorShiftsQueryHandler(IBaseService<DoctorShift> service)
        {
            this._service = service;
        }

        public async Task<HandlerResponse<List<DoctorShiftDisplayDto>>> Handle(GetAllDoctorShiftsQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _service.GetAll().AsQueryable();

            if (request.Date.HasValue)
                baseQuery = baseQuery.Where(x => x.StartTime <= request.Date.Value && x.EndTime >= request.Date.Value);

            if (request.ShiftStatus.HasValue)
                baseQuery = baseQuery.Where(x => x.Status == request.ShiftStatus.Value);

            return (await baseQuery.ToListAsync()).Adapt<List<DoctorShiftDisplayDto>>();
        }
    }
}
