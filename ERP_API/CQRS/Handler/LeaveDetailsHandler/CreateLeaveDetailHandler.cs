using ERP_API.CQRS.Command.LeaveDetailsCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;
using System.Diagnostics.Metrics;
using System.Net;

namespace ERP_API.CQRS.Handler.LeaveDetailsHandler
{
    public class CreateLeaveDetailsHandler : IRequestHandler<CreateLeaveDetailCommand, LeaveDetails>
    {
        private readonly ILeaveDetailRepo _iLeaveDetailsRepo;

        public CreateLeaveDetailsHandler(ILeaveDetailRepo iLeaveDetailsRepo)
        {
            _iLeaveDetailsRepo = iLeaveDetailsRepo;
        }
        public async Task<LeaveDetails> Handle(CreateLeaveDetailCommand request, CancellationToken cancellationToken)
        {
            var LeaveDetailsData = new LeaveDetailsViewModel()
            {
                LeaveTypeEnum = request.LeaveTypeEnum,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Reason = request.Reason,
            EmployeeID = request.EmployeeID,
            RoleId = request.RoleId,

        };
            return await _iLeaveDetailsRepo.CreateLeaveDetails(LeaveDetailsData);
        }
    }
}
