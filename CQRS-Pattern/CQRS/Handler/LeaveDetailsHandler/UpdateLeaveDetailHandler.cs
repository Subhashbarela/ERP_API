using AutoMapper;
using CQRS_Pattern.CQRS.Command.ClientCommand;
using CQRS_Pattern.CQRS.Command.LeaveDetailsCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace CQRS_Pattern.CQRS.Handler.ClientHandler
{
    public class UpdateLeaveDetailHandler : IRequestHandler<UpdateLeaveDetailCommand, LeaveDetails>
    {
        private readonly ILeaveDetailRepo _iLeaveDetailsRepo;
        private readonly IMapper _mapper;

        public UpdateLeaveDetailHandler(ILeaveDetailRepo iLeaveDetailsRepo,IMapper mapper)
        {
            _iLeaveDetailsRepo = iLeaveDetailsRepo;
            _mapper = mapper;
        }
        public async Task<LeaveDetails> Handle(UpdateLeaveDetailCommand request, CancellationToken cancellationToken)
        {
            var LeaveDetailsData = _mapper.Map<LeaveDetailsViewModel>(request);           
            return await _iLeaveDetailsRepo.UpdateLeaveDetailsAsync(LeaveDetailsData);
        }
    }
}
