using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface.AuthInterface
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> DeleteRoleAsync(int roleId);
        Task<bool> AssignRoleToUserAsync(int userId, int roleId, string userType);
        Task<bool> RemoveRoleFromUserAsync(int userId, string userType);
    }
}
