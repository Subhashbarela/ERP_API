using AutoMapper;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.ViewModels;
using System.Threading;

namespace ERP_API.CQRS.Command.EmployeeCommand
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public CreateEmployeeCommand(EmployeeViewModel employeeDTO, IMapper mapper)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeDTO);

            Username = employeeDTO.Username;
            FirstName = employeeDTO.FirstName;
            MiddleName = employeeDTO.MiddleName;
            LastName = employeeDTO.LastName;
            MobileNo = employeeDTO.MobileNo;
            Education = employeeDTO.Education;
            Designation = employeeDTO.Designation;
            ProfilePicture = employeeDTO.ProfilePicture;
            Address = employeeDTO.Address;
            State = employeeDTO.State;
            Country = employeeDTO.Country;
            Email = employeeDTO.Email;
            Password = employeeDTO.Password;
            Postcode = employeeDTO.Postcode;
            CreatedOn = employeeDTO.CreatedOn;
            CreatedBy = employeeDTO.CreatedBy;
            ModifiedOn = employeeDTO.ModifiedOn;
            ModifiedBy = employeeDTO.ModifiedBy;
            IsDeleted = employeeDTO.IsDeleted;
            ClientId = employeeDTO.ClientId;
            RoleId= employeeDTO.RoleId;
        }

        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
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
        public bool IsDeleted { get; set; } = false;
        public int ClientId { get; set; }
        public int RoleId { get; set; }

    }
}

