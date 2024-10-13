using AutoMapper;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Pattern.CQRS.Command.AdminCommand
{
    public class UpdateAdminCommand : IRequest<Admin>
    {
        public UpdateAdminCommand(AdminViewModel adminViewModels, IMapper mapper)
        {
            mapper.Map(adminViewModels, this); 
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
        public int RoleId { get; set; }
    }
}
