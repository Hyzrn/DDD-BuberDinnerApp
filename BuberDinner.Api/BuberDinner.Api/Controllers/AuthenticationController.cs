using BuberDinner.Application.Features.Authentication.Commands.Register;
using BuberDinner.Application.Features.Authentication.Common;
using BuberDinner.Application.Features.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {

        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            var registerResult = await _mediator.Send(command);

            return registerResult.Match(
                registerResult => Ok(_mapper.Map<AuthenticationResponse>(registerResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var authResult = await _mediator.Send(query);

            return authResult.Match(
                registerResult => Ok(_mapper.Map<AuthenticationResponse>(registerResult)),
                errors => Problem(errors));
        }
    }
}
