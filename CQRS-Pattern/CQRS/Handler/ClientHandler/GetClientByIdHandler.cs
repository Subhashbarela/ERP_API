using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace CQRS_Pattern.CQRS.Handler.ClientHandler
{
    public class GetClientByIdQuery : IRequest<Client>
    {
        public int Id { get; set; }
    }
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Client>
    {
        private readonly IClientRepo _iClientRepo;

        public GetClientByIdHandler(IClientRepo iClientRepo)
        {
            _iClientRepo = iClientRepo;
        }
        public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _iClientRepo.GetClientById(request.Id);
        }
    }
}
