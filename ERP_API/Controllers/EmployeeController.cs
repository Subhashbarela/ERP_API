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
using AutoMapper;

namespace ERP_API.Controllers
{
    [Authorize(Policy = AuthorizationPolicies.AdminOrHRManagerOrEmployee)]
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly SieveProcessor _sieveProcessor;
        private readonly IMapper _mapper; // Add this field

        public EmployeeController(ApplicationDbContext dbContext, IMediator mediator, SieveProcessor sieveProcessor, IMapper mapper) // Add IMapper to constructor
        {
            _mediator = mediator;
            _sieveProcessor = sieveProcessor;
            _mapper = mapper; // Initialize the _mapper field
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeViewModel employeeDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new CreateEmployeeCommand(employeeDTO, _mapper); // _mapper is now available
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
        public async Task<ActionResult> GetEmployeeList()
        {
            try
            {
                var command = new GetEmployeeListQuery(); // _mapper is now available
                var result = await _mediator.Send(command);
                return Ok(result);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok("Employee list is empty");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request." + ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetEmployeeDetail/{id}")]
        public async Task<ActionResult> GetEmployeeDetail(int id)
        {
            try
            {
                var command = new GetEmployeeByIdQuery { Id=id}; // You need to implement this query
                var result = await _mediator.Send(command);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound($"Employee with ID {id} not found.");
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
