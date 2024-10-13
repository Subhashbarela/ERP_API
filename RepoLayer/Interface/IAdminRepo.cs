using RepoLayer.Entity;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{
    public interface IAdminRepo
    {
        public Task<List<Admin>> GetAdminAsync();
        public Task<Admin> UpdateAdminAsync(AdminViewModel Admin);
    }
}
