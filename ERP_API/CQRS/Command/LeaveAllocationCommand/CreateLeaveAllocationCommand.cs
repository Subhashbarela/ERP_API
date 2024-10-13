using MediatR;
using RepoLayer.Entity;
using RepoLayer.ViewModels;

namespace ERP_API.CQRS.Command.LeaveAllocationCommand
{
    public class CreateLeaveAllocationCommand : IRequest<string>
    {
        public CreateLeaveAllocationCommand(LeaveAllocationViewModel leaveAllocation)
        {
            EmployeeId = leaveAllocation.EmployeeId;
            CasualLeave=leaveAllocation.CasualLeave;
            SickLeave=leaveAllocation.SickLeave;
            MaternityLeave=leaveAllocation.MaternityLeave;
            PaternityLeave=leaveAllocation.PaternityLeave;
        }
        public int EmployeeId { get; set; }
        public int CasualLeave { get; set; }
        public int SickLeave { get; set; }
        public int MaternityLeave { get; set; }
        public int PaternityLeave { get; set; }
    }
}
