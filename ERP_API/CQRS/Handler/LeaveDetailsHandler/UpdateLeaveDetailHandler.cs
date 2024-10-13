using ERP_API.CQRS.Command.ClientCommand;
using ERP_API.CQRS.Command.LeaveDetailsCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace ERP_API.CQRS.Handler.ClientHandler
{
    public class UpdateLeaveDetailHandler : IRequestHandler<UpdateLeaveDetailCommand, LeaveDetails>
    {
        private readonly ILeaveDetailRepo _iLeaveDetailsRepo;

        public UpdateLeaveDetailHandler(ILeaveDetailRepo iLeaveDetailsRepo)
        {
            _iLeaveDetailsRepo = iLeaveDetailsRepo;
        }
        public async Task<LeaveDetails> Handle(UpdateLeaveDetailCommand request, CancellationToken cancellationToken)
        {
            var LeaveDetailsData = new LeaveDetailsViewModel()
            {
                LeaveDetailsID=request.LeaveDetailsID,
                LeaveTypeEnum = request.LeaveTypeEnum,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Reason = request.Reason,
                EmployeeID = request.EmployeeID,
                RoleId = request.RoleId,
            };
            return await _iLeaveDetailsRepo.UpdateLeaveDetailsAsync(LeaveDetailsData);
        }
    }
}
