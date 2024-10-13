using MediatR;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.DataAccess;
using RepoLayer.Entity.SieveEmployeeModel;
using RepoLayer.Entity;
using RepoLayer.ViewModels;
using Sieve.Services;
using ERP_API.CQRS.Command.HRCommand;
using Microsoft.AspNetCore.Authorization;
using RepoLayer.Entity.AuthEntity;
using ERP_API.CQRS.Handler.HRHandler;
using ERP_API.CQRS.Handler.ClientHandler;

namespace ERP_API.Controllers
{
    [Authorize(Policy = AuthorizationPolicies.AdminOrHRManager)]
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HRController(ApplicationDbContext dbContext, IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> AddHR([FromBody] HRManagerViewModel HRDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new CreateHRCommand(HRDTO);
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return Ok(HRDTO);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request." + ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<HRManager>>> GetHRList()
        {
            var HRList = await _mediator.Send(new GetHRListQuery());            

            return Ok(HRList);
        }
        [HttpGet("{Id}")]
        public async Task<HRManager> GetHRById(int Id)
        {
            var HRList = await _mediator.Send(new GetHRByIdQuery() { Id = Id });
            return HRList;
        }
        [HttpPut]
        public async Task<ActionResult> UpdateHR([FromBody] HRManagerViewModel HRDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new UpdateHRCommand(HRDTO);
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return Ok(HRDTO);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request." + ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteHR(int Id)
        {
            var HRList = await _mediator.Send(new DeleteHRCommand() { Id = Id });
            return Ok(HRList);
        }
    }
}
