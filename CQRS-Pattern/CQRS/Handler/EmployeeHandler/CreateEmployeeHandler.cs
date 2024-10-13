using AutoMapper;
using CQRS_Pattern.CQRS.Command.EmployeeCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace CQRS_Pattern.CQRS.Handler.EmployeeHandler
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepo _iEmpRepo;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IEmployeeRepo iEmpRepo,IMapper mapper)
        {
            _iEmpRepo = iEmpRepo;
            _mapper = mapper;
        }
        public async Task<Employee> Handle(CreateEmployeeCommand employeeDTO, CancellationToken cancellationToken)
        {
            var employeeEntity = _mapper.Map<EmployeeViewModel>(cancellationToken);            
            return await _iEmpRepo.AddEmployee(employeeEntity);
        }
    }
}
