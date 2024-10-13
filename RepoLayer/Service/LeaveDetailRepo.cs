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
    public class LeaveDetailRepo: ILeaveDetailRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public LeaveDetailRepo(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<LeaveDetails> CreateLeaveDetails(LeaveDetailsViewModel request)
        {
            var LeaveDetailss=_mapper.Map<LeaveDetails>(request);
           
            var result = await _dbContext.LeaveDetails.AddAsync(LeaveDetailss);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
      
        public async Task<LeaveDetails> GetLeaveDetailsById(int Id)
        {
            var result = await _dbContext.LeaveDetails.FindAsync(Id);
            return result;
        }

        public async Task<List<LeaveDetails>> GetLeaveDetailsListAsync()
        {
            var result = await _dbContext.LeaveDetails.ToListAsync();
            return result;
        }       

        public async Task<LeaveDetails> UpdateLeaveDetailsAsync(LeaveDetailsViewModel request)
        {
            var LeaveDetailss = _mapper.Map<LeaveDetails>(request);

            var result = _dbContext.LeaveDetails.Update(LeaveDetailss);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
