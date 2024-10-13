using AutoMapper;
using CQRS_Pattern.CQRS.Command.ClientCommand;
using CQRS_Pattern.CQRS.Command.HRCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace CQRS_Pattern.CQRS.Handler.ClientHandler
{
    public class UpdateHRHandler : IRequestHandler<UpdateHRCommand, HRManager>
    {
        private readonly IHRManagerRepo _iHRRepo;
        private readonly IMapper _mapper;

        public UpdateHRHandler(IHRManagerRepo iHRRepo,IMapper mapper)
        {
            _iHRRepo = iHRRepo;
            _mapper = mapper;
        }

        public async Task<HRManager> Handle(UpdateHRCommand request, CancellationToken cancellationToken)
        {
            var HrData = _mapper.Map<HRManagerViewModel>(request);            
            return await _iHRRepo.UpdateHRManagerAsync(HrData);
        }
    }
}
