using MediatR;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.ViewModels;
using ERP_API.CQRS.Command.AdminCommand;
using Microsoft.AspNetCore.Authorization;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.DataAccess;
using RepoLayer.Entity;
using ERP_API.CQRS.Handler.AdminHandler;

namespace ERP_API.Controllers
{
    [Authorize(Policy = AuthorizationPolicies.AdminOrHRManager)]

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminController(ApplicationDbContext dbContext, IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<Admin>>> GetAdminList()
        {
            var AdminList = await _mediator.Send(new GetAdminQuery());            
            return Ok(AdminList);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAdmin([FromBody] AdminViewModel AdminDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new UpdateAdminCommand(AdminDTO);
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return Ok(AdminDTO);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request." + ex.Message);
                return BadRequest();
            }
        }
    }
}
