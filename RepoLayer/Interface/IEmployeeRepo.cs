using RepoLayer.Entity;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{
    public interface IEmployeeRepo
    {
        public Task<IEnumerable<Employee>> GetEmployeeListAsync();
        Task<List<Employee>> SearchEmployeeListAsync(string searchString);
        public Task<Employee> GetEmployeeById(int userId);
        Task<Employee> AddEmployee(EmployeeViewModel employee);
        public Task<Employee> UpdateEmployeeAsync(EmployeeViewModel employee);
        public Task<string> DeleteEmployeeAsync(int Id);
    }
}
