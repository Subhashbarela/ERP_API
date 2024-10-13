using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.DataAccess;
using RepoLayer.Interface.AuthInterface;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Service.AuthService
{
    public class UserManagerRepo : IUserManagerRepo
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _dbContext;
        public UserManagerRepo(ApplicationDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }
        public Task<bool> ResetPassword(ResetPasswordViewModel model, string email)
        {
            throw new NotImplementedException();
        }

        public Task<ForgotPasswordViewModel> UserForgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UserLogin(UserLoginViewModel userCredentials)
        {
            // Check for Employee
            var user = await _dbContext.Employees
                .Include(e => e.Role)
                .FirstOrDefaultAsync(x => x.Username == userCredentials.UserName && x.Password == userCredentials.Password);

            if (user != null)
            {
                var token = GenerateJWToken(user.Email, user.Id, user.Role.RoleName);
                return token;
            }

            // Check for Admin
           var user1 = await _dbContext.Admins
                .Include(a => a.Role)
                .FirstOrDefaultAsync(x => x.Username == userCredentials.UserName && x.Password == userCredentials.Password);

            if (user1 != null)
            {
                var token = GenerateJWToken(user1.Email, user1.AdminID, user1.Role.RoleName);
                return token;
            }

            // Check for HRManager
           var user2 = await _dbContext.HRManagers
                .Include(h => h.Role)
                .FirstOrDefaultAsync(x => x.Username == userCredentials.UserName && x.Password == userCredentials.Password);

            if (user2 != null)
            {
                var token = GenerateJWToken(user2.Email, user2.HRmanagerId, user2.Role.RoleName);
                return token;
            }

            // Check for Client
           var user3 = await _dbContext.Clients
                .Include(c => c.Role)
                .FirstOrDefaultAsync(x => x.Username == userCredentials.UserName && x.Password == userCredentials.Password);

            if (user3 != null)
            {
                var token = GenerateJWToken(user3.Email, user3.Id, user3.Role.RoleName);
                return token;
            }

            // If no user is found, return an empty string
            return string.Empty;
        }

       
        private string GenerateJWToken(string emailId, int userId, string roleName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create claims for email, user ID, and roles
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, emailId),
            new Claim("UserId", userId.ToString()),
            new Claim(ClaimTypes.Role, roleName)
        };

            // Create JWT token
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            // Return the JWT token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    //public async Task<string> UserLogin(UserLoginViewModel userCredentials)
    //{
    //    var employee = _dbContext.Employees.FirstOrDefault(x => x.Username == userCredentials.UserName && x.Password == userCredentials.Password);
    //    var admin = _dbContext.Admins.FirstOrDefault(x => x.Username == userCredentials.UserName && x.Password == userCredentials.Password);

    //    if (employee != null)
    //    {
    //        var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.RoleId == employee.RoleId);
    //        if (role != null)
    //        {
    //            var token = GenerateJWToken(employee.Email, employee.Id, role.RoleName);
    //            return token;
    //        }
    //    }
    //    else if (admin != null)
    //    {
    //        var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.RoleId == admin.RoleId);
    //        if (role != null)
    //        {
    //            var token = GenerateJWToken(admin.Email, admin.AdminID, role.RoleName);
    //            return token;
    //        }
    //    }
    //    return string.Empty;
    //}
}
