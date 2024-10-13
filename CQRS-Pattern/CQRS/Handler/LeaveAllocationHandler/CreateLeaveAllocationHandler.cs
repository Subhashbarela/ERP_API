using AutoMapper;
using CQRS_Pattern.CQRS.Command.ClientCommand;
using CQRS_Pattern.CQRS.Command.LeaveAllocationCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.Service;
using RepoLayer.ViewModels;

namespace CQRS_Pattern.CQRS.Handler.LeaveAllocationHandler
{
    public class CreateLeaveAllocationHandler : IRequestHandler<CreateLeaveAllocationCommand, string>
    {
        private readonly ILeaveAllocationRepo _leaveAllocationRepo;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationHandler(ILeaveAllocationRepo leaveAllocationRepo,IMapper mapper)
        {
            _leaveAllocationRepo = leaveAllocationRepo;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<LeaveAllocationViewModel>(request);            
            return await _leaveAllocationRepo.CreateAllocation(result);
        }
    }
}
