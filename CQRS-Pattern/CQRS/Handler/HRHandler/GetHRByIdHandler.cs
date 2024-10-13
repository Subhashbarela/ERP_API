using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace CQRS_Pattern.CQRS.Handler.HRHandler
{
    public class GetHRByIdQuery : IRequest<HRManager> { public int Id { get; set; } }
    public class GetHRByIdHandler : IRequestHandler<GetHRByIdQuery, HRManager>
    {
        private readonly IHRManagerRepo _managerRepo;
        public GetHRByIdHandler(IHRManagerRepo managerRepo)
        {
            _managerRepo = managerRepo;
        }
        public async Task<HRManager> Handle(GetHRByIdQuery request, CancellationToken cancellationToken)
        {
            return await _managerRepo.GetHRManagerById(request.Id);
         }
    }
}
