using CleanArchitecture.Application.CQRS.DoctorShiftFiles.Commands;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using Mapster;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorShiftFiles.Handlers
{
    public class UpdateDoctorShiftChangeStatusCommandHandler : IRequestHandler<UpdateDoctorShiftChangeStatusCommand, HandlerResponse<DoctorShiftDisplayDto>>
    {
        private readonly IBaseService<DoctorShift> _service;

        public UpdateDoctorShiftChangeStatusCommandHandler(IBaseService<DoctorShift> service)
        {
            this._service = service;
        }

        public async Task<HandlerResponse<DoctorShiftDisplayDto>> Handle(UpdateDoctorShiftChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _service.GetByIdAsync(cancellationToken, request.DoctorShiftChangeStatus.Id);

            if (entity == null)
                return new(false, "شیفت مورد نظر یافت نشد", null);

            request.DoctorShiftChangeStatus.Adapt(entity);
            var result = await _service.UpdateAsync(entity, cancellationToken);
            return result.Adapt<DoctorShiftDisplayDto>();
        }
    }
}
