﻿using AutoMapper;
using MediatR;
using RepoLayer.Entity;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Pattern.CQRS.Command.HRCommand
{
    public class CreateHRCommand : IRequest<HRManager>
    {
        public CreateHRCommand(HRManagerViewModel HRManagerViewModel,IMapper mapper)
        {
            mapper.Map(HRManagerViewModel,this);           
        }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNo { get; set; }
        public string? Education { get; set; }
        public string? Designation { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Postcode { get; set; }
        public int RoleId { get; set; }
    }
}
