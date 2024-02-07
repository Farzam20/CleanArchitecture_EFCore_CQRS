using CleanArchitecture.Application.CQRS.DoctorFiles.Commands;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using Mapster;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorFiles.Handlers
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, HandlerResponse<DoctorDisplayDto>>
    {
        private readonly IBaseService<Doctor> _service;

        public UpdateDoctorCommandHandler(IBaseService<Doctor> service)
        {
            this._service = service;
        }

        public async Task<HandlerResponse<DoctorDisplayDto>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _service.GetByIdAsync(cancellationToken, request.Doctor.Id);

            if (entity == null)
                return new(false, "دکتر مورد نظر یافت نشد", null);

            request.Doctor.Adapt(entity);
            var result = await _service.UpdateAsync(entity, cancellationToken);
            return result.Adapt<DoctorDisplayDto>();
        }
    }
}
