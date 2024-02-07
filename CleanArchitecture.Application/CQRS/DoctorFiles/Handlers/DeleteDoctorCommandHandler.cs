using CleanArchitecture.Application.CQRS.DoctorFiles.Commands;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorFiles.Handlers
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<Doctor> _service;

        public DeleteDoctorCommandHandler(IBaseService<Doctor> service)
        {
            this._service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (entity == null)
                return new(false, "دکتر موردنظر یافت نشد", false);

            await _service.DeleteAsync(entity, cancellationToken);
            return true;
        }
    }
}
