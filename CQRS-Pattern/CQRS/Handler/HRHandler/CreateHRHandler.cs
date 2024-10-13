using AutoMapper;
using CQRS_Pattern.CQRS.Command.ClientCommand;
using CQRS_Pattern.CQRS.Command.HRCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;
using System.Diagnostics.Metrics;
using System.Net;

namespace CQRS_Pattern.CQRS.Handler.ClientHandler
{
    public class CreateHRHandler : IRequestHandler<CreateHRCommand, HRManager>
    {
        private readonly IHRManagerRepo _iHRRepo;
        private readonly IMapper _mapper;

        public CreateHRHandler(IHRManagerRepo iHRRepo,IMapper mapper)
        {
            _iHRRepo = iHRRepo;
            _mapper = mapper;
        }
        public async Task<HRManager> Handle(CreateHRCommand request, CancellationToken cancellationToken)
        {
            var HrData = _mapper.Map<HRManagerViewModel>(request);            
            return await _iHRRepo.CreateHRManager(HrData);
        }
    }
}
