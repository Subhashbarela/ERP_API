using AutoMapper;
using CQRS_Pattern.CQRS.Command.AdminCommand;
using CQRS_Pattern.CQRS.Command.ClientCommand;
using CQRS_Pattern.CQRS.Command.EmployeeCommand;
using CQRS_Pattern.CQRS.Command.HRCommand;
using CQRS_Pattern.CQRS.Command.LeaveAllocationCommand;
using CQRS_Pattern.CQRS.Command.LeaveDetailsCommand;
using RepoLayer.Entity;
using RepoLayer.ViewModels;
namespace CQRS_Pattern.MappingModel
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Create a mapping and reverse it in one line
            CreateMap<AdminViewModel, Admin>().ReverseMap();
            CreateMap<ClientViewModels, Client>().ReverseMap();
            CreateMap<HRManagerViewModel, HRManager>().ReverseMap();
            CreateMap<LeaveAllocationViewModel, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocationViewModel, LeaveAllocation>()
            .ForMember(dest => dest.TotalLeave, opt => opt.Ignore()); 
            CreateMap<LeaveAllocation, LeaveAllocationViewModel>().ReverseMap();
            CreateMap<EmployeeViewModel, Employee>().ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.Now)) 
            .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore()).ReverseMap();
            CreateMap<EmployeeViewModel, CreateEmployeeCommand>().ReverseMap();
            CreateMap<EmployeeViewModel, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<AdminViewModel, UpdateAdminCommand>().ReverseMap();
            CreateMap<ClientViewModels, CreateClientCommand>().ReverseMap();
            CreateMap<ClientViewModels, UpdateClientCommand>().ReverseMap();
            CreateMap<HRManagerViewModel, CreateHRCommand>().ReverseMap();
            CreateMap<HRManagerViewModel, UpdateHRCommand>().ReverseMap();
            CreateMap<LeaveAllocationViewModel, CreateLeaveAllocationCommand>().ReverseMap();
            CreateMap<LeaveAllocationViewModel, UpdateLeaveAllocationCommand>().ReverseMap();
            CreateMap<LeaveDetailsViewModel, CreateLeaveDetailCommand>().ReverseMap();
            CreateMap<LeaveDetailsViewModel, UpdateLeaveDetailCommand>().ReverseMap();
        }

    }
}
