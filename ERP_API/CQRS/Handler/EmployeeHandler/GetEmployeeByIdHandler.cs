using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace ERP_API.CQRS.Handler.EmployeeHandler
{

    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery,Employee>
    {
        private readonly IEmployeeRepo _iEmpRepo;

        public GetEmployeeByIdHandler(IEmployeeRepo iEmpRepo)
        {
            _iEmpRepo = iEmpRepo;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _iEmpRepo.GetEmployeeById(request.Id);
        }
    }


}
