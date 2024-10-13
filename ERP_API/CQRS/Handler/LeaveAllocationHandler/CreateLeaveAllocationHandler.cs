using ERP_API.CQRS.Command.ClientCommand;
using ERP_API.CQRS.Command.LeaveAllocationCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.Service;
using RepoLayer.ViewModels;

namespace ERP_API.CQRS.Handler.LeaveAllocationHandler
{
    public class CreateLeaveAllocationHandler : IRequestHandler<CreateLeaveAllocationCommand, string>
    {
        private readonly ILeaveAllocationRepo _leaveAllocationRepo;

        public CreateLeaveAllocationHandler(ILeaveAllocationRepo leaveAllocationRepo)
        {
            _leaveAllocationRepo = leaveAllocationRepo;
        }

        public async Task<string> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var result = new LeaveAllocationViewModel()
            {
                EmployeeId = request.EmployeeId,
                CasualLeave = request.CasualLeave,
                SickLeave = request.SickLeave,
                MaternityLeave = request.MaternityLeave,
                PaternityLeave = request.PaternityLeave,
            };
            return await _leaveAllocationRepo.CreateAllocation(result);

        }
    }
}
