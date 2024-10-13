using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace ERP_API.CQRS.Handler.LeaveAllocationHandler
{
    public class GetLeaveAllocationByIdQuery : IRequest<LeaveAllocation>
    {
        public int Id { get; set; }
    }
    public class GetLeaveAllocationByIdHandler : IRequestHandler<GetLeaveAllocationByIdQuery, LeaveAllocation>
    {
        private readonly ILeaveAllocationRepo _leaveAllocationRepo;

        public GetLeaveAllocationByIdHandler(ILeaveAllocationRepo leaveAllocationRepo)
        {
            _leaveAllocationRepo = leaveAllocationRepo;
        }

        public async Task<LeaveAllocation> Handle(GetLeaveAllocationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _leaveAllocationRepo.GetLeaveAllocationByEmpId(request.Id);
        }
    }
}
