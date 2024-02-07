using CleanArchitecture.Application.CQRS.PatientFiles.Queries;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.CQRS.PatientFiles.Handlers
{
    public class GetPatientByNationalCodeQueryHandler : IRequestHandler<GetPatientByNationalCodeQuery, HandlerResponse<PatientDisplayDto>>
    {
        private readonly IBaseService<Patient> _service;

        public GetPatientByNationalCodeQueryHandler(IBaseService<Patient> service)
        {
            this._service = service;
        }

        public async Task<HandlerResponse<PatientDisplayDto>> Handle(GetPatientByNationalCodeQuery request, CancellationToken cancellationToken)
        {
            var entity = await _service.GetAll(x => x.NationalCode == request.NationalCode).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                return new(false, "بیمار موردنظر یافت نشد", null);

            return entity.Adapt<PatientDisplayDto>();
        }
    }
}
