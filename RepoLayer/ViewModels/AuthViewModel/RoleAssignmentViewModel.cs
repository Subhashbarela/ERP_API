using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.ViewModels.AuthViewModel
{
    public class RoleAssignmentViewModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserType { get; set; }
    }
    public class RoleRemovalViewModel
    {
        public int UserId { get; set; }
        public string UserType { get; set; }
    }
}
