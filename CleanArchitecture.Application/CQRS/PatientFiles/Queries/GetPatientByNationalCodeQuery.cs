using CleanArchitecture.Application.Dtos;
using MediatR;

namespace CleanArchitecture.Application.CQRS.PatientFiles.Queries
{
    public class GetPatientByNationalCodeQuery : IRequest<HandlerResponse<PatientDisplayDto>>
    {
        public string NationalCode { get; }

        public GetPatientByNationalCodeQuery(string nationalCode)
        {
            NationalCode = nationalCode;
        }

    }
}
