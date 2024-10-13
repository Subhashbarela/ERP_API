using ERP_API.CQRS.Command.ClientCommand;
using ERP_API.CQRS.Command.LeaveAllocationCommand;
using ERP_API.CQRS.Handler.LeaveAllocationHandler;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.DataAccess;
using RepoLayer.Entity;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.ViewModels;

namespace ERP_API.Controllers
{
    [Authorize(Policy = AuthorizationPolicies.AdminOrHRManagerOrEmployee)]

    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveAllocationController(ApplicationDbContext dbContext, IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> AddLeaveAllocation([FromBody] LeaveAllocationViewModel leaveAllocation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new CreateLeaveAllocationCommand(leaveAllocation);
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return Ok(leaveAllocation);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request." + ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocation>>> GetLeaveAllocationList()
        {
            var LeaveAllocationList = await _mediator.Send(new GetLeaveAllocationListQuery());
            return Ok(LeaveAllocationList);
        }
        [HttpGet("{Id}")]
        public async Task<LeaveAllocation> GetLeaveAllocationById(int Id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationByIdQuery() { Id = Id });
            return leaveAllocation;
        }
        [HttpPut]
        public async Task<ActionResult> UpdateLeaveAllocation([FromBody] LeaveAllocationViewModel leaveAllocation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new UpdateLeaveAllocationCommand(leaveAllocation);
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return Ok(leaveAllocation);
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
