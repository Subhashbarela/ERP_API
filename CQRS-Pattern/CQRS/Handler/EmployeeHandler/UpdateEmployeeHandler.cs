using AutoMapper;
using CQRS_Pattern.CQRS.Command.EmployeeCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;

namespace CQRS_Pattern.CQRS.Handler.EmployeeHandler
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepo _iEmpRepo;
        private readonly IMapper _mapper;

        public UpdateEmployeeHandler(IEmployeeRepo iEmpRepo,IMapper mapper)
        {
            _iEmpRepo = iEmpRepo;
            _mapper = mapper;
        }
        public async Task<Employee> Handle(UpdateEmployeeCommand employeeDTO, CancellationToken cancellationToken)
        {
            var employeeData = _mapper.Map<EmployeeViewModel>(employeeDTO);            
            return await _iEmpRepo.UpdateEmployeeAsync(employeeData);
        }
    }
}
