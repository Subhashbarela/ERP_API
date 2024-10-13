using ERP_API.CQRS.Handler.AuthHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.ViewModels;

namespace ERP_API.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody]UserLoginViewModel login)
        {
            var result = await _mediator.Send(new UserManagerCommand() { Password = login.Password, Username = login.UserName });
            return Ok( result );
        }
    }
}
