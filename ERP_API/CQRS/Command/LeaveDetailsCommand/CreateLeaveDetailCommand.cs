using MediatR;
using RepoLayer.Entity;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.Entity.Enum;
using RepoLayer.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Net;

namespace ERP_API.CQRS.Command.LeaveDetailsCommand
{
    public class CreateLeaveDetailCommand: IRequest<LeaveDetails>
    {
        public CreateLeaveDetailCommand(LeaveDetailsViewModel request)
        {

            LeaveTypeEnum = request.LeaveTypeEnum;
            StartDate = request.StartDate;
            EndDate = request.EndDate;
            Reason = request.Reason;
            EmployeeID = request.EmployeeID;
            RoleId = request.RoleId;
        }
        public LeaveTypeEnum LeaveTypeEnum { get; set; }       
        public DateTime StartDate { get; set; }       
        public DateTime EndDate { get; set; }
        public int NoOfDays { get; set; }
        public string? Reason { get; set; }              
        public int EmployeeID { get; set; }
        public int RoleId { get; set; }
    }
}
