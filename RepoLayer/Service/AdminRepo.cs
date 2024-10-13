using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepoLayer.DataAccess;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Service
{
    public class AdminRepo:IAdminRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper; // Inject IMapper

        public AdminRepo(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }      
       
        public async Task<List<Admin>> GetAdminAsync()
        {
            var result = await _dbContext.Admins.ToListAsync();
            return result;
        }
        
        public async Task<Admin> UpdateAdminAsync(AdminViewModel request)
        {
            var adminData = _mapper.Map<Admin>(request);           
            var result = _dbContext.Admins.Update(adminData);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
