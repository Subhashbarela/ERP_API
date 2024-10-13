using ERP_API.CQRS.Command.ClientCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.DataAccess;
using RepoLayer.Entity;
using RepoLayer.ViewModels;
using Sieve.Services;
using Microsoft.AspNetCore.Authorization;
using RepoLayer.Entity.AuthEntity;
using ERP_API.CQRS.Handler.ClientHandler;

namespace ERP_API.Controllers
{
    [Authorize(Policy = AuthorizationPolicies.AdminOrHRManagerOrClient)]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly SieveProcessor _sieveProcessor;


        public ClientController(ApplicationDbContext dbContext, IMediator mediator, SieveProcessor sieveProcessor)
        {
            _mediator = mediator;
            _sieveProcessor = sieveProcessor;
        }
        [HttpPost]
        public async Task<ActionResult> AddClient([FromBody] ClientViewModels ClientDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new CreateClientCommand(ClientDTO);
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return Ok(ClientDTO);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request." + ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClientList()
        {
            var ClientList = await _mediator.Send(new GetClientListQuery());
            return Ok(ClientList);
        }
        [HttpGet("{Id}")]
        public async Task<Client> GetClientById(int Id)
        {
            var ClientList = await _mediator.Send(new GetClientByIdQuery() { Id = Id });
            return ClientList;
        }
        [HttpPut]
        public async Task<ActionResult> UpdateClient([FromBody] ClientViewModels ClientDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new UpdateClientCommand(ClientDTO);
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return Ok(ClientDTO);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request." + ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteClient(int Id)
        {
            var ClientList = await _mediator.Send(new DeleteClientCommand() { Id = Id });
            return Ok(ClientList);
        }

    }
}
