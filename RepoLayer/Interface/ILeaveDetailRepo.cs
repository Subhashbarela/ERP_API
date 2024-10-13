using RepoLayer.Entity;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{
    public interface ILeaveDetailRepo
    {
        public Task<List<LeaveDetails>> GetLeaveDetailsListAsync();
        public Task<LeaveDetails> GetLeaveDetailsById(int Id);
        Task<LeaveDetails> CreateLeaveDetails(LeaveDetailsViewModel LeaveDetails);
        public Task<LeaveDetails> UpdateLeaveDetailsAsync(LeaveDetailsViewModel LeaveDetails);
    }
}
