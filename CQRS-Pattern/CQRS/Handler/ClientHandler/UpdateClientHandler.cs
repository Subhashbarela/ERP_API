using AutoMapper;
using CQRS_Pattern.CQRS.Command.ClientCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace CQRS_Pattern.CQRS.Handler.ClientHandler
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, Client>
    {
        private readonly IClientRepo _iClientRepo;
        private readonly IMapper _mapper;

        public UpdateClientHandler(IClientRepo iClientRepo,IMapper mapper)
        {
            _iClientRepo=iClientRepo;
            _mapper = mapper;
        }

        public async Task<Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var clientData=_mapper.Map<ClientViewModels>(request);       
            return await _iClientRepo.UpdateClientAsync(clientData);
        }
    }
}
