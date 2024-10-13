using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.Service;

namespace ERP_API.Controllers
{
    [Authorize(Policy = AuthorizationPolicies.Admin)]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManagerService _roleManagerService;

        public RoleController(RoleManagerService roleManagerService)
        {
            _roleManagerService = roleManagerService;
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await _roleManagerService.CreateRoleAsync(roleName);
            if (result)
            {
                return Ok("Role created successfully.");
            }
            return BadRequest("Failed to create role.");
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole(string userId, string roleName)
        {
            var result = await _roleManagerService.AssignRoleToUserAsync(userId, roleName);
            if (result)
            {
                return Ok("Role assigned successfully.");
            }
            return BadRequest("Failed to assign role.");
        }

        [HttpPost("remove-role")]
        public async Task<IActionResult> RemoveRole(string userId, string roleName)
        {
            var result = await _roleManagerService.RemoveRoleFromUserAsync(userId, roleName);
            if (result)
            {
                return Ok("Role removed successfully.");
            }
            return BadRequest("Failed to remove role.");
        }
    }
}
