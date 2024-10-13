using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RepoLayer.DataAccess;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Service
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepo(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<Employee> AddEmployee(EmployeeViewModel request)
        {
            try
            {
                var roles = await _dbContext.Roles.Where(r => r.RoleId == request.RoleId).FirstOrDefaultAsync();
                if (roles.RoleId == 1)
                {
                    var employees = _mapper.Map<Employee>(request);                   

                    var result = await _dbContext.Employees.AddAsync(employees);
                    await _dbContext.SaveChangesAsync();
                    return result.Entity;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteEmployeeAsync(int Id)
        {
            var result = _dbContext.Employees.FirstOrDefault(x => x.Id == Id);
            _dbContext.Employees.Remove(result);
            _dbContext.SaveChanges();
            return "employee deleted successfully";
        }

        public async Task<Employee> GetEmployeeById(int userId)
        {
            var employee = await _dbContext.Employees.Where(x => x.Id == userId).FirstOrDefaultAsync();
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeListAsync()
        {
            var result = await _dbContext.Employees.ToListAsync();
            return result;
        }
        
        public Task<List<Employee>> SearchEmployeeListAsync(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> UpdateEmployeeAsync(EmployeeViewModel request)
        {
            var employees = _mapper.Map<Employee>(request);            
            var result = _dbContext.Employees.Update(employees);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
