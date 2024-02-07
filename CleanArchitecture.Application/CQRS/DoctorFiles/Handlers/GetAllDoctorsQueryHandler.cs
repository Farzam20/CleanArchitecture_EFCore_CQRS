using CleanArchitecture.Application.CQRS.DoctorFiles.Queries;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.DoctorFiles.Handlers
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, HandlerResponse<List<DoctorDisplayDto>>>
    {
        private readonly IBaseService<Doctor> _service;

        public GetAllDoctorsQueryHandler(IBaseService<Doctor> service)
        {
            this._service = service;
        }

        public async Task<HandlerResponse<List<DoctorDisplayDto>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _service.GetAll();
            return (await baseQuery.ToListAsync()).Adapt<List<DoctorDisplayDto>>();
        }
    }
}
