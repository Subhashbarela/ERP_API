using ERP_API.CQRS.Command.EmployeeCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.DataAccess;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.Entity;
using RepoLayer.ViewModels;
using Sieve.Services;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ERP_API.CQRS.Handler.EmployeeHandler;

namespace ERP_API.Controllers
{
    [Authorize(Policy = AuthorizationPolicies.AdminOrHRManagerOrEmployee)]
    [Route("api/Employee")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly SieveProcessor _sieveProcessor;


        public EmployeeController(ApplicationDbContext dbContext, IMediator mediator, SieveProcessor sieveProcessor)
        {
            _mediator = mediator;
            _sieveProcessor= sieveProcessor;
        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeViewModel employeeDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new CreateEmployeeCommand(employeeDTO);
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return Ok(employeeDTO);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request." + ex.Message);
                return BadRequest();
            }
        }
        
        [HttpGet]
        [Route("GetEmployeeList")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeList()
        {
            try
            {
                var employeeList = await _mediator.Send(new GetEmployeeListQuery());
                return Ok(employeeList); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving employee list: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("GetEmployeeById")]

        public async Task<Employee> GetEmployeeById(int userId)
        {
            var employeeList = await _mediator.Send(new GetEmployeeByIdQuery() { Id = userId });
            return employeeList;
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployee([FromBody] EmployeeViewModel employeeDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new UpdateEmployeeCommand(employeeDTO);
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return Ok(employeeDTO);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request." + ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteEmployee(int Id)
        {
            var employeeList = await _mediator.Send(new DeleteEmployeeCommand() { Id = Id });
            return Ok(employeeList);
        }
        
    }
}
