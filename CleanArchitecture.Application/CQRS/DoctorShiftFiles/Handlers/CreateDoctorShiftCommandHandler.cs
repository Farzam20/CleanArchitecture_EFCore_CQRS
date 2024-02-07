using CleanArchitecture.Application.CQRS.DoctorShiftFiles.Commands;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using Mapster;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorShiftFiles.Handlers
{
    public class CreateDoctorShiftCommandHandler : IRequestHandler<CreateDoctorShiftCommand, HandlerResponse<DoctorShiftDisplayDto>>
    {
        private readonly IBaseService<DoctorShift> _service;

        public CreateDoctorShiftCommandHandler(IBaseService<DoctorShift> service)
        {
            this._service = service;
        }

        public async Task<HandlerResponse<DoctorShiftDisplayDto>> Handle(CreateDoctorShiftCommand request, CancellationToken cancellationToken)
        {
            var entity = request.DoctorShift.Adapt<DoctorShift>();
            var result = await _service.AddAsync(entity, cancellationToken);

            return result.Adapt<DoctorShiftDisplayDto>();
        }
    }
}
