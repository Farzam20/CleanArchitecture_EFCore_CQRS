using CleanArchitecture.API.Utilities;
using CleanArchitecture.API.Utilities.Api;
using CleanArchitecture.API.Utilities.Filters;
using CleanArchitecture.Application.CQRS.DoctorFiles.Commands;
using CleanArchitecture.Application.CQRS.DoctorFiles.Queries;
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
    [Authorize(Roles = "Admin")]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<DoctorCreateDto> _validator;

        public DoctorController(IMediator mediator, IValidator<DoctorCreateDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<List<DoctorDisplayDto>>> Get()
        {
            var query = new GetAllDoctorsQuery();
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("GetById")]
        public async Task<ApiResult<DoctorDisplayDto>> Get(int id)
        {
            var query = new GetDoctorQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<DoctorDisplayDto>> Post(DoctorCreateDto model)
        {
            var result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreateDoctorCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut]
        public async Task<ApiResult<DoctorDisplayDto>> Put(DoctorCreateDto model)
        {
            var result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdateDoctorCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(int id)
        {
            var command = new DeleteDoctorCommand(id);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok();

            return BadRequest(handlerResponse.Message);
        }
    }
}
