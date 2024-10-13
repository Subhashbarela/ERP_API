using ERP_API.CQRS.Command.ClientCommand;
using ERP_API.CQRS.Command.HRCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;
using System.Diagnostics.Metrics;
using System.Net;

namespace ERP_API.CQRS.Handler.ClientHandler
{
    public class CreateHRHandler : IRequestHandler<CreateHRCommand, HRManager>
    {
        private readonly IHRManagerRepo _iHRRepo;

        public CreateHRHandler(IHRManagerRepo iHRRepo)
        {
            _iHRRepo = iHRRepo;
        }
        public async Task<HRManager> Handle(CreateHRCommand request, CancellationToken cancellationToken)
        {
            var HrData = new HRManagerViewModel()
            {
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
            return await _iHRRepo.CreateHRManager(HrData);
        }
    }
}
