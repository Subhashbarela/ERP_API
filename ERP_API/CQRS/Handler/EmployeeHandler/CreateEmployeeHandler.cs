using AutoMapper;
using ERP_API.CQRS.Command.EmployeeCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace ERP_API.CQRS.Handler.EmployeeHandler
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepo _iEmpRepo;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IEmployeeRepo iEmpRepo, IMapper mapper)
        {
            _iEmpRepo = iEmpRepo;
            _mapper = mapper;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Map the request (CreateEmployeeCommand) to EmployeeViewModel
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(request);

            // Save the employee entity to the database using the repository
            var savedEmployee = await _iEmpRepo.AddEmployee(employeeViewModel);

            // Map the saved EmployeeViewModel back to Employee
            return _mapper.Map<Employee>(savedEmployee);
        }
    }
}
