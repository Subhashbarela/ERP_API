using MediatR;
using RepoLayer.Entity;
using RepoLayer.ViewModels;

namespace ERP_API.CQRS.Command.AdminCommand
{
    public class UpdateAdminCommand : IRequest<Admin>
    {
        public UpdateAdminCommand(AdminViewModel adminViewModels)
        {
            AdminId = adminViewModels.AdminID;
            Username = adminViewModels.Username;
            FirstName = adminViewModels.FirstName;
            LastName = adminViewModels.LastName;
            MobileNo = adminViewModels.MobileNo;
            Education = adminViewModels.Education;
            Designation = adminViewModels.Designation;
            ProfilePicture = adminViewModels.ProfilePicture;
            Address = adminViewModels.Address;
            State = adminViewModels.State;
            Country = adminViewModels.Country;
            Email = adminViewModels.Email;
            Password = adminViewModels.Password;
            Postcode = adminViewModels.Postcode;
           
        }

        public int AdminId { get; set; }
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
        public int RoleId  { get; set; }
       
    }
}

