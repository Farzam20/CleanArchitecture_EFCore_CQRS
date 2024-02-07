using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.API.Utilities.Api;
using CleanArchitecture.API.Utilities.Filters;
using CleanArchitecture.Application.CQRS.UserFiles.Queries;
using CleanArchitecture.Application.Dtos;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<LoginDto> _loginValidator;

        public AccountController(IMediator mediator, IValidator<LoginDto> loginValidator)
        {
            _mediator = mediator;
            _loginValidator = loginValidator;
        }

        [HttpPost("[action]")]
        public async Task<ApiResult<string>> Login(LoginDto model)
        {
            var validationResult = await _loginValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new LoginQuery(model.UserName, model.Password);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Test()
        {
            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "User")]
        public async Task<ApiResult> Test2()
        {
            return Ok();
        }
    }
}