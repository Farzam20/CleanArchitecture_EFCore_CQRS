using CleanArchitecture.Application.CQRS.DoctorFiles.Queries;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using Mapster;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorFiles.Handlers
{
    public class GetDoctorQueryHandler : IRequestHandler<GetDoctorQuery, HandlerResponse<DoctorDisplayDto>>
    {
        private readonly IBaseService<Doctor> _service;

        public GetDoctorQueryHandler(IBaseService<Doctor> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<DoctorDisplayDto>> Handle(GetDoctorQuery request, CancellationToken cancellationToken)
        {
            var entity = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (entity == null)
                return new(false, "دکتر موردنظر یافت نشد", null);

            return entity.Adapt<DoctorDisplayDto>();
        }
    }
}
