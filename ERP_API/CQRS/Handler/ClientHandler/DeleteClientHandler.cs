using ERP_API.CQRS.Command.ClientCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace ERP_API.CQRS.Handler.ClientHandler
{
    public class DeleteClientCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, string>
    {
        private readonly IClientRepo _iClientRepo;
        public DeleteClientHandler(IClientRepo iClientRepo)
        {
            _iClientRepo = iClientRepo;
        }
        public async Task<string> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            return await _iClientRepo.DeleteClientAsync(request.Id);
        }
    }
}
