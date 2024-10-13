using AutoMapper;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Entity.Enum;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Pattern.CQRS.Command.LeaveDetailsCommand
{
    public class CreateLeaveDetailCommand : IRequest<LeaveDetails>
    {
        public CreateLeaveDetailCommand(LeaveDetailsViewModel request,IMapper mapper)
        {
            mapper.Map(request, this);           
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
