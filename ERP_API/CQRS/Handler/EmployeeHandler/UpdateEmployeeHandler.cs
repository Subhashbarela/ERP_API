using ERP_API.CQRS.Command.EmployeeCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace ERP_API.CQRS.Handler.EmployeeHandler
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepo _iEmpRepo;

        public UpdateEmployeeHandler(IEmployeeRepo iEmpRepo)
        {
            _iEmpRepo = iEmpRepo;
        }
        public async Task<Employee> Handle(UpdateEmployeeCommand employeeDTO, CancellationToken cancellationToken)
        {
            var employeeData = new EmployeeViewModel()
            {
                Id= employeeDTO.Id,
                Username = employeeDTO.Username,
                FirstName = employeeDTO.FirstName,
                MiddleName = employeeDTO.MiddleName,
                LastName = employeeDTO.LastName,
                MobileNo = employeeDTO.MobileNo,
                Education = employeeDTO.Education,
                Designation = employeeDTO.Designation,
                ProfilePicture = employeeDTO.ProfilePicture,
                Address = employeeDTO.Address,
                State = employeeDTO.State,
                Country = employeeDTO.Country,
                Email = employeeDTO.Email,
                Password = employeeDTO.Password,
                Postcode = employeeDTO.Postcode,
                CreatedOn = employeeDTO.CreatedOn,
                CreatedBy = employeeDTO.CreatedBy,
                ModifiedOn = employeeDTO.ModifiedOn,
                ModifiedBy = employeeDTO.ModifiedBy,
                IsDeleted = employeeDTO.IsDeleted,
                ClientId = employeeDTO.ClientId,
            };
            return await _iEmpRepo.UpdateEmployeeAsync(employeeData);
        }
    }
}
