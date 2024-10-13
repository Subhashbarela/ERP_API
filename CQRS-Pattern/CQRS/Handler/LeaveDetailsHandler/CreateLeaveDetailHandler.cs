using AutoMapper;
using CQRS_Pattern.CQRS.Command.LeaveDetailsCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;
using System.Diagnostics.Metrics;
using System.Net;

namespace CQRS_Pattern.CQRS.Handler.LeaveDetailsHandler
{
    public class CreateLeaveDetailsHandler : IRequestHandler<CreateLeaveDetailCommand, LeaveDetails>
    {
        private readonly ILeaveDetailRepo _iLeaveDetailsRepo;
        private readonly IMapper _mapper;

        public CreateLeaveDetailsHandler(ILeaveDetailRepo iLeaveDetailsRepo,IMapper mapper)
        {
            _iLeaveDetailsRepo = iLeaveDetailsRepo;
            _mapper = mapper;
        }
        public async Task<LeaveDetails> Handle(CreateLeaveDetailCommand request, CancellationToken cancellationToken)
        {
            var LeaveDetailsData = _mapper.Map<LeaveDetailsViewModel>(request);            
            return await _iLeaveDetailsRepo.CreateLeaveDetails(LeaveDetailsData);
        }
    }
}
