using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace ERP_API.CQRS.Handler.LeaveDetailsHandler
{
    public class GetLeaveDetailByIdQuery : IRequest<LeaveDetails>
    {
        public int Id { get; set; }
    }
    public class GetLeaveDetailByIdHandler : IRequestHandler<GetLeaveDetailByIdQuery, LeaveDetails>
    {
        private readonly ILeaveDetailRepo _iLeaveDetailsRepo;

        public GetLeaveDetailByIdHandler(ILeaveDetailRepo iLeaveDetailsRepo)
        {
            _iLeaveDetailsRepo = iLeaveDetailsRepo;
        }
        public async Task<LeaveDetails> Handle(GetLeaveDetailByIdQuery request, CancellationToken cancellationToken)
        {
            return await _iLeaveDetailsRepo.GetLeaveDetailsById(request.Id);
        }
    }
}
