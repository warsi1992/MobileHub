using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileHub.Application.Features.Auth.Login;
using MobileHub.Application.Features.Auth.Register;
using MobileHub.Domain.Entities;

namespace MobileHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(new
            {
                UserId = id,
                Message = "Registration successful."
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var token = await _mediator.Send(command);

            return Ok(new
            {
                Token = token.Token,
                UserId = token.UserId,
                FirstName = token.FirstName,
                Role = token.Role
            });
        }
    }
}
