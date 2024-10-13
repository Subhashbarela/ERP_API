using ERP_API.CQRS.Command.ClientCommand;
using ERP_API.CQRS.Command.HRCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace ERP_API.CQRS.Handler.ClientHandler
{
    public class UpdateHRHandler : IRequestHandler<UpdateHRCommand, HRManager>
    {
        private readonly IHRManagerRepo _iHRRepo;

        public UpdateHRHandler(IHRManagerRepo iHRRepo)
        {
            _iHRRepo = iHRRepo;
        }

        public async Task<HRManager> Handle(UpdateHRCommand request, CancellationToken cancellationToken)
        {
            var HrData = new HRManagerViewModel()
            {
                HRmanagerId=request.HRManagerID,
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MobileNo = request.MobileNo,
                Education = request.Education,
                Designation = request.Designation,
                ProfilePicture = request.ProfilePicture,
                Address = request.Address,
                State = request.State,
                Country = request.Country,
                Email = request.Email,
                Password = request.Password,
                Postcode = request.Postcode,
                RoleId = request.RoleId,
            };
            return await _iHRRepo.UpdateHRManagerAsync(HrData);
        }
    }
}
