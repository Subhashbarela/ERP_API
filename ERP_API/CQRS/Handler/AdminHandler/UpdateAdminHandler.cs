using ERP_API.CQRS.Command.AdminCommand;
using ERP_API.CQRS.Command.ClientCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.Service;
using RepoLayer.ViewModels;

namespace ERP_API.CQRS.Handler.AdminHandler
{
    public class UpdateAdminHandler : IRequestHandler<UpdateAdminCommand, Admin>
    {
        private readonly IAdminRepo _adminRepo;

        public UpdateAdminHandler(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public async Task<Admin> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var adminData = new AdminViewModel()
            {
                AdminID = request.AdminId,
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
                RoleId=request.RoleId
            };
            return await _adminRepo.UpdateAdminAsync(adminData);
        }
    }
}

