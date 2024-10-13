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
    public class HRManagerRepo:IHRManagerRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public HRManagerRepo(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<HRManager> CreateHRManager(HRManagerViewModel request)
        {
            var HRManagers = _mapper.Map<HRManager>(request);
           
            var result = await _dbContext.HRManagers.AddAsync(HRManagers);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<string> DeleteHRManagerAsync(int Id)
        {
            var result = _dbContext.HRManagers.FirstOrDefault(x => x.HRmanagerId == Id);
            _dbContext.HRManagers.Remove(result);
            _dbContext.SaveChanges();
            return "HRManager deleted successfully";
        }

        public async Task<HRManager> GetHRManagerById(int Id)
        {
            var result = await _dbContext.HRManagers.FindAsync(Id);
            return result;
        }

        public async Task<List<HRManager>> GetHRManagerListAsync()
        {
            var result = await _dbContext.HRManagers.ToListAsync();
            return result;
        }

        public Task<List<HRManager>> SearchHRManagerListAsync(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<HRManager> UpdateHRManagerAsync(HRManagerViewModel request)
        {
            var HRManagers = _mapper.Map<HRManager>(request);
            
            var result = _dbContext.HRManagers.Update(HRManagers);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
