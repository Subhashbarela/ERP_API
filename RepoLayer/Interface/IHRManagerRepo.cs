using RepoLayer.Entity;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{
    public interface IHRManagerRepo
    {
        public Task<List<HRManager>> GetHRManagerListAsync();
        Task<List<HRManager>> SearchHRManagerListAsync(string searchString);
        public Task<HRManager> GetHRManagerById(int Id);
        Task<HRManager> CreateHRManager(HRManagerViewModel HRManager);
        public Task<HRManager> UpdateHRManagerAsync(HRManagerViewModel HRManager);
        public Task<string> DeleteHRManagerAsync(int Id);
    }
}
