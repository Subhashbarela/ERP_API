using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace CQRS_Pattern.CQRS.Handler.HRHandler
{
    public class GetHRListQuery : IRequest<List<HRManager>> { }

    public class GetHRListHandler:IRequestHandler<GetHRListQuery,List<HRManager>>
    {
        private readonly IHRManagerRepo _managerRepo;
        public GetHRListHandler(IHRManagerRepo managerRepo)
        {
            _managerRepo = managerRepo;
        }
        public async Task<List<HRManager>> Handle(GetHRListQuery request, CancellationToken cancellationToken)
        {
            return await _managerRepo.GetHRManagerListAsync();
        }
    }
}
