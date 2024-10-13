using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace ERP_API.CQRS.Handler.EmployeeHandler
{
    public class GetEmployeeListQuery : IRequest<IEnumerable<Employee>>
    {
    }
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepo _iEmpRepo;

        public GetEmployeeListHandler(IEmployeeRepo iEmpRepo)
        {
            _iEmpRepo = iEmpRepo;
        }

        public async Task<IEnumerable<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await _iEmpRepo.GetEmployeeListAsync();
        }
    }

}
