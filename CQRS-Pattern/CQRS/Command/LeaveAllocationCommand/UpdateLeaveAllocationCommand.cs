using AutoMapper;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Pattern.CQRS.Command.LeaveAllocationCommand
{
    public class UpdateLeaveAllocationCommand : IRequest<LeaveAllocation>
    {
        public UpdateLeaveAllocationCommand(LeaveAllocationViewModel leaveAllocation,IMapper mapper)
        {
            mapper.Map(leaveAllocation,this);           
        }
        public int LeaveAllocationId { get; set; }
        public int EmployeeId { get; set; }
        public int CasualLeave { get; set; }
        public int SickLeave { get; set; }
        public int MaternityLeave { get; set; }
        public int PaternityLeave { get; set; }
    }
}
