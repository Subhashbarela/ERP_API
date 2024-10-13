using ERP_API.CQRS.Command.ClientCommand;
using ERP_API.CQRS.Command.HRCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace ERP_API.CQRS.Handler.ClientHandler
{
    public class DeleteHRCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
    public class DeleteHRHandler : IRequestHandler<DeleteHRCommand, string>
    {
        private readonly IHRManagerRepo _iHRRepo;

        public DeleteHRHandler(IHRManagerRepo iHRRepo)
        {
            _iHRRepo = iHRRepo;
        }
        public async Task<string> Handle(DeleteHRCommand request, CancellationToken cancellationToken)
        {
            return await _iHRRepo.DeleteHRManagerAsync(request.Id);
        }
    }
}
