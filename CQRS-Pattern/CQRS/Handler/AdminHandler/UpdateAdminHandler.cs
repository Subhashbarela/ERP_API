using AutoMapper;
using CQRS_Pattern.CQRS.Command.AdminCommand;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Pattern.CQRS.Handler.AdminHandler
{
    public class UpdateAdminHandler : IRequestHandler<UpdateAdminCommand, Admin>
    {
        private readonly IAdminRepo _adminRepo;
        private readonly IMapper _mapper;
        public UpdateAdminHandler(IAdminRepo adminRepo,IMapper mapper)
        {
            _adminRepo = adminRepo;
            _mapper = mapper;
        }
        public async Task<Admin> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var adminData = _mapper.Map<AdminViewModel>(request);          

            return await _adminRepo.UpdateAdminAsync(adminData);
        }
    }
}
