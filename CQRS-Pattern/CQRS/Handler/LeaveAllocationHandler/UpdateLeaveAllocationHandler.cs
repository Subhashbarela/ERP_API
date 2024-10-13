using AutoMapper;
using CQRS_Pattern.CQRS.Command.LeaveAllocationCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace CQRS_Pattern.CQRS.Handler.LeaveAllocationHandler
{
    public class UpdateLeaveAllocationHandler : IRequestHandler<UpdateLeaveAllocationCommand, LeaveAllocation>
    {
        private readonly ILeaveAllocationRepo _leaveAllocationRepo;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationHandler(ILeaveAllocationRepo leaveAllocationRepo,IMapper mapper)
        {
            _leaveAllocationRepo = leaveAllocationRepo;
            _mapper = mapper;
        }

        public async Task<LeaveAllocation> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<LeaveAllocationViewModel>(request);           
            return await _leaveAllocationRepo.UpdateLeaveAllocation(result);
        }
    }
}
