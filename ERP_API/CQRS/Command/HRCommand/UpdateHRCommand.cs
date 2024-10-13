using MediatR;
using RepoLayer.Entity;
using RepoLayer.Entity.AuthEntity;
using RepoLayer.ViewModels;
using System.Diagnostics.Metrics;
using System.Net;

namespace ERP_API.CQRS.Command.HRCommand
{
    public class UpdateHRCommand : IRequest<HRManager>
    {
        public UpdateHRCommand(HRManagerViewModel HRManagerViewModel)
        {
            HRManagerID = HRManagerViewModel.HRmanagerId;
            Username = HRManagerViewModel.Username;
            FirstName = HRManagerViewModel.FirstName;
            LastName = HRManagerViewModel.LastName;
            MobileNo = HRManagerViewModel.MobileNo;
            Education = HRManagerViewModel.Education;
            Designation = HRManagerViewModel.Designation;
            ProfilePicture = HRManagerViewModel.ProfilePicture;
            Address = HRManagerViewModel.Address;
            State = HRManagerViewModel.State;
            Country = HRManagerViewModel.Country;
            Email = HRManagerViewModel.Email;
            Password = HRManagerViewModel.Password;
            Postcode = HRManagerViewModel.Postcode;           
            RoleId = HRManagerViewModel.RoleId;
        }

        public int HRManagerID { get; set; }
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
        public int RoleId { get; set; }
    }
}
