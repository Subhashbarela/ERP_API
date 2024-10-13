using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Pattern.CQRS.Handler.AdminHandler
{
    public class GetAdminQuery : IRequest<List<Admin>>  {  }
    public class GetAdminHandler : IRequestHandler<GetAdminQuery, List<Admin>>
    {
        private readonly IAdminRepo _adminRepo;

        public GetAdminHandler(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
        }
        public async Task<List<Admin>> Handle(GetAdminQuery request, CancellationToken cancellationToken)
        {
            return await _adminRepo.GetAdminAsync();
        }
    }
}
