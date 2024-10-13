using RepoLayer.Entity;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{
    public interface ILeaveAllocationRepo
    {       
        Task<List<LeaveAllocation>> GetLeaveAllocationListAsync();
        Task<LeaveAllocation> GetLeaveAllocationByEmpId(int id);
        Task<LeaveAllocation> UpdateLeaveAllocation(LeaveAllocationViewModel allocationViewModel);
        Task<string> CreateAllocation(LeaveAllocationViewModel allocationViewModel );
    }
}
