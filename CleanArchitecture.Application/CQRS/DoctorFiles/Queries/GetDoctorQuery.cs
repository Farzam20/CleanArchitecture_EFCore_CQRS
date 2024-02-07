using CleanArchitecture.Application.Dtos;
using MediatR;

namespace CleanArchitecture.Application.CQRS.DoctorFiles.Queries
{
    public class GetDoctorQuery : IRequest<HandlerResponse<DoctorDisplayDto>>
    {
        public int Id { get; }

        public GetDoctorQuery(int id) 
        { 
            this.Id = id;
        }
    }
}
