using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using RepoLayer.Entity.AuthEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Entity.AuthEntity
{

    public static class AuthorizationPolicies
    {
        public const string Admin = "Admin";
        public const string HRManager = "HRManager";
        public const string Employee = "Employee";
        public const string Client = "Client";

        // Combined role policies
        public const string AdminOrHRManager = "AdminOrHRManager";
        public const string AdminOrHRManagerOrEmployee = "AdminOrHRManagerOrEmployee";
        public const string AdminOrHRManagerOrClient = "AdminOrHRManagerOrClient";

        public static void AddPolicies(AuthorizationOptions options)
        {
            options.AddPolicy(Admin, policy => policy.RequireRole(Admin));
            options.AddPolicy(HRManager, policy => policy.RequireRole(HRManager));
            options.AddPolicy(Employee, policy => policy.RequireRole(Employee));
            options.AddPolicy(Client, policy => policy.RequireRole(Client));

            // Combined role policies
            options.AddPolicy(AdminOrHRManager, policy => policy.RequireRole(Admin, HRManager));
            options.AddPolicy(AdminOrHRManagerOrEmployee, policy => policy.RequireRole(Admin, HRManager, Employee));
            options.AddPolicy(AdminOrHRManagerOrClient, policy => policy.RequireRole(Admin, HRManager, Client));
        }
    }
}

