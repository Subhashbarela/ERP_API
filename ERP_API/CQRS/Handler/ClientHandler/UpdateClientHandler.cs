using ERP_API.CQRS.Command.ClientCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace ERP_API.CQRS.Handler.ClientHandler
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, Client>
    {
        private readonly IClientRepo _iClientRepo;

        public UpdateClientHandler(IClientRepo iClientRepo)
        {
            _iClientRepo=iClientRepo;
        }

        public async Task<Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var clientData = new ClientViewModels()
            {
               Id = request.Id,
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
                Pincode = request.Postcode,
                CreatedOn = request.CreatedOn,
                CreatedBy = request.CreatedBy,
                ModifiedOn = request.ModifiedOn,
                ModifiedBy = request.ModifiedBy,
                RoleId = request.RoleId,

            };
            return await _iClientRepo.UpdateClientAsync(clientData);
        }
    }
}
