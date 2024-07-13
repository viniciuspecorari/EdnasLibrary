using EdnasLibrary.Application.Commands.AuthJwt;
using EdnasLibrary.Application.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdnasLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> AddUser(AddUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);                      
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(AuthJwtCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]       
        public ActionResult GetStatus()
        {
            return Ok("Hello Admin!");
        }
    }
}
