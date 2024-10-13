using RepoLayer.Entity;
using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{
    public interface IClientRepo
    {
        public Task<List<Client>> GetClientListAsync();
        Task<List<Client>> SearchClientListAsync(string searchString);
        public Task<Client> GetClientById(int Id);
        Task<Client> CreateClient(ClientViewModels client);
        public Task<Client> UpdateClientAsync(ClientViewModels client);
        public Task<string> DeleteClientAsync(int Id);
    }
}
