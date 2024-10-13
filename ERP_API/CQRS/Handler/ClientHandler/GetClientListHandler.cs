using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace ERP_API.CQRS.Handler.ClientHandler
{
    public class GetClientListQuery : IRequest<List<Client>> { }

    public class GetClientListHandler : IRequestHandler<GetClientListQuery, List<Client>>
    {
        private readonly IClientRepo _iClientRepo;

        public GetClientListHandler(IClientRepo iClientRepo)
        {
            _iClientRepo = iClientRepo;
        }

        public async Task<List<Client>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {
            return await _iClientRepo.GetClientListAsync();
        }
    }
}
