using CleanArchitecture.API.Utilities.Api;
using CleanArchitecture.API.Utilities.Filters;
using CleanArchitecture.Application.CQRS.DoctorShiftFiles.Queries;
using CleanArchitecture.Application.CQRS.PatientFiles.Queries;
using CleanArchitecture.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    [AllowAnonymous]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<ApiResult<PatientDisplayDto>> GetByNationalCode(string nationalCode)
        {
            var query = new GetPatientByNationalCodeQuery(nationalCode);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }
    }
}
