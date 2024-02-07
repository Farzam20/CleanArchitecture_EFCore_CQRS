using CleanArchitecture.API.Utilities.Api;
using CleanArchitecture.API.Utilities.Filters;
using CleanArchitecture.Application.CQRS.AppointmentFiles.Commands;
using CleanArchitecture.Application.Dtos;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    [AllowAnonymous]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<AppointmentCreateDto> _validator;

        public AppointmentController(IMediator mediator, IValidator<AppointmentCreateDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpPost]
        public async Task<ApiResult<AppointmentDisplayDto>> Post(AppointmentCreateDto model)
        {
            var result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreateAppointmentCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }
    }
}
