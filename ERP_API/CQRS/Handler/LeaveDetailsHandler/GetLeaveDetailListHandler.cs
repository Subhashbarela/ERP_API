using MediatR;
using RepoLayer.Interface;
using RepoLayer.Entity;

namespace ERP_API.CQRS.Handler.LeaveDetailsHandler
{
    public class GetLeaveDetailListQuery : IRequest<List<LeaveDetails>> { }

    public class GetLeaveDetailListHandler : IRequestHandler<GetLeaveDetailListQuery, List<LeaveDetails>>
    {
        private readonly ILeaveDetailRepo _iLeaveDetailRepo;

        public GetLeaveDetailListHandler(ILeaveDetailRepo iLeaveDetailRepo)
        {
            _iLeaveDetailRepo = iLeaveDetailRepo;
        }

        public async Task<List<LeaveDetails>> Handle(GetLeaveDetailListQuery request, CancellationToken cancellationToken)
        {
            return await _iLeaveDetailRepo.GetLeaveDetailsListAsync();
        }
    }
}
