using MediatR;
using RepoLayer.Entity;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.ViewModels;
using System.Diagnostics.Metrics;
using System.Net;

namespace ERP_API.CQRS.Command.ClientCommand
{
    public class UpdateClientCommand : IRequest<Client>
    {
        public UpdateClientCommand(ClientViewModels clientViewModels)
        {
            Id= clientViewModels.Id;
            Username = clientViewModels.Username;
            FirstName = clientViewModels.FirstName;
            LastName = clientViewModels.LastName;
            MobileNo = clientViewModels.MobileNo;
            Education = clientViewModels.Education;
            Designation = clientViewModels.Designation;
            ProfilePicture = clientViewModels.ProfilePicture;
            Address = clientViewModels.Address;
            State = clientViewModels.State;
            Country = clientViewModels.Country;
            Email = clientViewModels.Email;
            Password = clientViewModels.Password;
            Postcode = clientViewModels.Pincode;
            CreatedOn = clientViewModels.CreatedOn;
            CreatedBy = clientViewModels.CreatedBy;
            ModifiedOn = clientViewModels.ModifiedOn;
            ModifiedBy = clientViewModels.ModifiedBy;
            RoleId = clientViewModels.RoleId;
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNo { get; set; }
        public string? Education { get; set; }
        public string? Designation { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Postcode { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public int RoleId { get; set; }
    }
}
