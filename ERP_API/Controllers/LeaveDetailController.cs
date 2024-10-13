using ERP_API.CQRS.Command.LeaveAllocationCommand;
using ERP_API.CQRS.Command.LeaveDetailsCommand;
using ERP_API.CQRS.Handler.LeaveDetailsHandler;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class LeaveDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveDetailController(ApplicationDbContext dbContext, IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> AddLeaveDetails([FromBody] LeaveDetailsViewModel leaveDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new CreateLeaveDetailCommand(leaveDetail);
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return Ok(leaveDetail);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request." + ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<LeaveDetails>>> GetLeaveDetailList()
        {
            var LeaveDetailList = await _mediator.Send(new GetLeaveDetailListQuery());
            return Ok(LeaveDetailList);
        }
        [HttpGet("{Id}")]
        public async Task<LeaveDetails> GetLeaveDetailById(int Id)
        {
            var leaveDetail = await _mediator.Send(new GetLeaveDetailByIdQuery() { Id = Id });
            return leaveDetail;
        }
        [HttpPut]
        public async Task<ActionResult> UpdateLeaveDetail([FromBody] LeaveDetailsViewModel leaveDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new UpdateLeaveDetailCommand(leaveDetail);
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return Ok(leaveDetail);
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
