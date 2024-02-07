using CleanArchitecture.Application.CQRS.DoctorFiles.Commands;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using Mapster;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorFiles.Handlers
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, HandlerResponse<DoctorDisplayDto>>
    {
        private readonly IBaseService<Doctor> _service;

        public CreateDoctorCommandHandler(IBaseService<Doctor> service)
        {
            this._service = service;
        }

        public async Task<HandlerResponse<DoctorDisplayDto>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Doctor.Adapt<Doctor>();
            var result = await _service.AddAsync(entity, cancellationToken);

            return result.Adapt<DoctorDisplayDto>();
        }
    }
}
