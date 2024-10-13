using MediatR;
using RepoLayer.Entity;
using RepoLayer.Entity.Enum;
using RepoLayer.ViewModels;

namespace ERP_API.CQRS.Command.LeaveDetailsCommand
{
    public class UpdateLeaveDetailCommand:IRequest<LeaveDetails>
    {
        public UpdateLeaveDetailCommand(LeaveDetailsViewModel request)
        {
            LeaveDetailsID = request.LeaveDetailsID;
            LeaveTypeEnum = request.LeaveTypeEnum;
            StartDate = request.StartDate;
            EndDate = request.EndDate;
            Reason = request.Reason;
            EmployeeID = request.EmployeeID;
            RoleId = request.RoleId;
        }
        public int LeaveDetailsID { get; set; }
        public LeaveTypeEnum LeaveTypeEnum { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoOfDays { get; set; }
        public string? Reason { get; set; }
        public int EmployeeID { get; set; }
        public int RoleId { get; set; }
    }
}

