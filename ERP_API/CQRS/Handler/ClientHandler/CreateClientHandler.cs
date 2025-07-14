using ERP_API.CQRS.Command.ClientCommand;
using ERP_API.CQRS.Command.HRCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.Interface;
using RepoLayer.Service;
using RepoLayer.ViewModels;
using System.Diagnostics.Metrics;
using System.Net;

namespace ERP_API.CQRS.Handler.HRHandler
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, Client>
    {
        private readonly IClientRepo _iClientRepo;

        public CreateClientHandler(IClientRepo iClientRepo)
        {
            _iClientRepo = iClientRepo;
        }
        public async Task<Client> Handle(CreateClientCommand clientViewModels, CancellationToken cancellationToken)
        {
            var ClientData = new ClientViewModels()
            {
                Username = clientViewModels.Username,
            FirstName = clientViewModels.FirstName,
            LastName = clientViewModels.LastName,
            MobileNo = clientViewModels.MobileNo,
            Education = clientViewModels.Education,
            Designation = clientViewModels.Designation,
            ProfilePicture = clientViewModels.ProfilePicture,
            Address = clientViewModels.Address,
            State = clientViewModels.State,
            Country = clientViewModels.Country,
            Email = clientViewModels.Email,
            Password = clientViewModels.Password,
            Pincode = clientViewModels.Postcode,
            CreatedOn = clientViewModels.CreatedOn,
            CreatedBy = clientViewModels.CreatedBy,
            ModifiedOn = clientViewModels.ModifiedOn,
            ModifiedBy = clientViewModels.ModifiedBy,
            RoleId = clientViewModels.RoleId,

        };
            return await _iClientRepo.CreateClient(ClientData);
        }
    }
}
