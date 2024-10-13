using CQRS_Pattern.CQRS.Command.EmployeeCommand;
using MediatR;
using RepoLayer.Interface;

namespace CQRS_Pattern.CQRS.Handler.EmployeeHandler
{
    public class DeleteEmployeeCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, string>
    {
        private readonly IEmployeeRepo _iEmpRepo;

        public DeleteEmployeeHandler(IEmployeeRepo iEmpRepo)
        {
            _iEmpRepo = iEmpRepo;
        }

        public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _iEmpRepo.DeleteEmployeeAsync(request.Id);
        }
    }
}
