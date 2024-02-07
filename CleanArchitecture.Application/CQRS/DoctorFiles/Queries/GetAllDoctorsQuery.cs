using CleanArchitecture.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.DoctorFiles.Queries
{
    public class GetAllDoctorsQuery : IRequest<HandlerResponse<List<DoctorDisplayDto>>>
    {
        public GetAllDoctorsQuery()
        {
        }
    }
}
