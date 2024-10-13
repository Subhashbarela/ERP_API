using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.Interface.AuthInterface;
using RepoLayer.ViewModels.AuthViewModel;

namespace ERP_API.Controllers.AuthController
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = AuthorizationPolicies.Admin)]

    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await _roleService.CreateRoleAsync(roleName);
            if (result)
            {
                return Ok("Role created successfully.");
            }
            return BadRequest("Role already exists.");
        }

        [HttpDelete]
        [Route("delete/{roleId}")]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            var result = await _roleService.DeleteRoleAsync(roleId);
            if (result)
            {
                return Ok("Role deleted successfully.");
            }
            return NotFound("Role not found.");
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] RoleAssignmentViewModel dto)
        {
            var result = await _roleService.AssignRoleToUserAsync(dto.UserId, dto.RoleId, dto.UserType);
            if (result)
            {
                return Ok(new { message = "Role assigned successfully." });
            }
            return BadRequest(new { message = "Failed to assign role." });
        }

        [HttpPost("remove-role")]
        public async Task<IActionResult> RemoveRoleFromUser([FromBody] RoleAssignmentViewModel dto)
        {
            var result = await _roleService.RemoveRoleFromUserAsync(dto.UserId, dto.UserType);
            if (result)
            {
                return Ok(new { message = "Role removed successfully." });
            }
            return BadRequest(new { message = "Failed to remove role." });
        }

    }
}
