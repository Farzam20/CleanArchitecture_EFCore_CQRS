using CleanArchitecture.API.Utilities.Api;
using CleanArchitecture.API.Utilities.Filters;
using CleanArchitecture.Application.CQRS.DoctorShiftFiles.Commands;
using CleanArchitecture.Application.CQRS.DoctorShiftFiles.Queries;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Domain.Enums;
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
    [Authorize(Roles = "Admin")]
    public class DoctorShiftController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<DoctorShiftCreateDto> _validator;

        public DoctorShiftController(IMediator mediator, IValidator<DoctorShiftCreateDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ApiResult<List<DoctorShiftDisplayDto>>> Get(DateTime? date = null, ShiftStatus? shiftStatus = null)
        {
            var query = new GetAllDoctorShiftsQuery(date, shiftStatus);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<DoctorShiftDisplayDto>> Post(DoctorShiftCreateDto model)
        {
            var result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreateDoctorShiftCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut]
        public async Task<ApiResult<DoctorShiftDisplayDto>> Put(DoctorShiftChangeStatusDto model)
        {
            var command = new UpdateDoctorShiftChangeStatusCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }
    }
}