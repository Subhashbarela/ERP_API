using RepoLayer.DataAccess;
using RepoLayer.Entity;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.Interface.AuthInterface;

namespace RepoLayer.Service.AuthService
{
    public class RoleService:IRoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            if (!_context.Roles.Any(r => r.RoleName == roleName))
            {
                _context.Roles.Add(new Role { RoleName = roleName });
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteRoleAsync(int roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> AssignRoleToUserAsync(int userId, int roleId, string userType)
        {
            var user = await GetUserByIdAsync(userId, userType);
            var role = await _context.Roles.FindAsync(roleId);

            if (user != null && role != null)
            {
                switch (userType.ToLower())
                {
                    case "employee":
                        ((Employee)user).RoleId = roleId;
                        ((Employee)user).Role = role;
                        break;
                    case "client":
                        ((Client)user).RoleId = roleId;
                        ((Client)user).Role = role;
                        break;
                    case "hr":
                        ((HRManager)user).RoleId = roleId;
                        ((HRManager)user).Role = role;
                        break;
                    default:
                        return false;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveRoleFromUserAsync(int userId, string userType)
        {
            var user = await GetUserByIdAsync(userId, userType);

            if (user != null)
            {
                switch (userType.ToLower())
                {
                    case "employee":
                        ((Employee)user).RoleId = 0; // Assuming 0 or null means no role
                        ((Employee)user).Role = null;
                        break;
                    case "client":
                        ((Client)user).RoleId = 0; // Assuming 0 or null means no role
                        ((Client)user).Role = null;
                        break;
                    case "hrmanager":
                        ((HRManager)user).RoleId = 0; // Assuming 0 or null means no role
                        ((HRManager)user).Role = null;
                        break;
                    default:
                        return false;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<object> GetUserByIdAsync(int userId, string userType)
        {
            switch (userType.ToLower())
            {
                case "employee":
                    return await _context.Employees.FindAsync(userId);
                case "client":
                    return await _context.Clients.FindAsync(userId);
                case "hrmanager":
                    return await _context.HRManagers.FindAsync(userId);
                default:
                    return null;
            }
        }

    }
}
