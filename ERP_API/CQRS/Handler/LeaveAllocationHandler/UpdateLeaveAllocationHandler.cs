using ERP_API.CQRS.Command.LeaveAllocationCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace ERP_API.CQRS.Handler.LeaveAllocationHandler
{
    public class UpdateLeaveAllocationHandler : IRequestHandler<UpdateLeaveAllocationCommand, LeaveAllocation>
    {
        private readonly ILeaveAllocationRepo _leaveAllocationRepo;

        public UpdateLeaveAllocationHandler(ILeaveAllocationRepo leaveAllocationRepo)
        {
            _leaveAllocationRepo = leaveAllocationRepo;
        }

        public async Task<LeaveAllocation> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var result = new LeaveAllocationViewModel()
            {
                LeaveAllocationId= request.LeaveAllocationId,
                EmployeeId = request.EmployeeId,
                CasualLeave = request.CasualLeave,
                SickLeave = request.SickLeave,
                MaternityLeave = request.MaternityLeave,
                PaternityLeave = request.PaternityLeave,
            };
            return await _leaveAllocationRepo.UpdateLeaveAllocation(result);
        }
    }
}
