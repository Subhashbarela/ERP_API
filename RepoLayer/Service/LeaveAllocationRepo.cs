using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepoLayer.DataAccess;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace RepoLayer.Service
{
    public class LeaveAllocationRepo : ILeaveAllocationRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public LeaveAllocationRepo(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<string> CreateAllocation(LeaveAllocationViewModel allocationViewModel)
        {
            var leave = _mapper.Map<LeaveAllocation>(allocationViewModel);
            leave.TotalLeave = allocationViewModel.CasualLeave + allocationViewModel.SickLeave + allocationViewModel.MaternityLeave + allocationViewModel.PaternityLeave;           
            var response=await _dbContext.LeaveAllocations.AddAsync(leave);
             _dbContext.SaveChanges();
            return response.ToString();
        }
        public async Task<string> DeleteLeaveAllocationByEmpId(int id)
        {
            var response = await _dbContext.LeaveAllocations.Where(x => x.EmployeeId == id).FirstOrDefaultAsync();
            if (response == null)
            {
                return "Data is not found";
            }
            _dbContext.SaveChanges();
            return response.ToString();
        }
        public async Task<LeaveAllocation> GetLeaveAllocationByEmpId(int id)
        {
            var response = await _dbContext.LeaveAllocations.Where(x => x.EmployeeId == id).FirstOrDefaultAsync();
            if (response == null)
            {
                return null;
            }
            return response;
        }
        public async Task<List<LeaveAllocation>> GetLeaveAllocationListAsync()
        {
            var response = await _dbContext.LeaveAllocations.ToListAsync();
            if (response == null)
            {
                return null;
            }
            return response;
        }
        public async Task<LeaveAllocation> UpdateLeaveAllocation(LeaveAllocationViewModel allocationViewModel)
        {
            var response = await _dbContext.LeaveAllocations.FirstOrDefaultAsync(x => x.EmployeeId == allocationViewModel.EmployeeId);
            if (response != null)
            {
                _mapper.Map(allocationViewModel, response);
                response.TotalLeave = response.CasualLeave + response.SickLeave + response.MaternityLeave + response.PaternityLeave;

                await _dbContext.SaveChangesAsync();
                return response;
            }
            return null;
        }
    }
}
