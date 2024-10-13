using AutoMapper;
using CQRS_Pattern.CQRS.Command.ClientCommand;
using CQRS_Pattern.CQRS.Command.HRCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.Interface;
using RepoLayer.Service;
using RepoLayer.ViewModels;
using System.Diagnostics.Metrics;
using System.Net;

namespace CQRS_Pattern.CQRS.Handler.ClientHandler
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, Client>
    {
        private readonly IClientRepo _iClientRepo;
        private readonly IMapper _mapper;

        public CreateClientHandler(IClientRepo iClientRepo,IMapper mapper)
        {
            _iClientRepo = iClientRepo;
            _mapper = mapper;
        }
        public async Task<Client> Handle(CreateClientCommand clientViewModels, CancellationToken cancellationToken)
        {
            var ClientData=_mapper.Map<ClientViewModels>(clientViewModels);           
            return await _iClientRepo.CreateClient(ClientData);
        }
    }
}
