using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace ERP_API.CQRS.Handler.LeaveAllocationHandler
{
    public class GetLeaveAllocationListQuery : IRequest<List<LeaveAllocation>> { }

    public class GetLeaveAllocationListHandler : IRequestHandler<GetLeaveAllocationListQuery, List<LeaveAllocation>>
    {
        private readonly ILeaveAllocationRepo _leaveAllocationRepo;

        public GetLeaveAllocationListHandler(ILeaveAllocationRepo leaveAllocationRepo)
        {
            _leaveAllocationRepo = leaveAllocationRepo;
        }
        public async Task<List<LeaveAllocation>> Handle(GetLeaveAllocationListQuery request, CancellationToken cancellationToken)
        {
            return await _leaveAllocationRepo.GetLeaveAllocationListAsync();
        }
    }
}
