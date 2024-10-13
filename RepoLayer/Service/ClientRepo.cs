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
    public class ClientRepo:IClientRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ClientRepo(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Client> CreateClient(ClientViewModels request)
        {
            var Clients=_mapper.Map<Client>(request);
            
            var result = await _dbContext.Clients.AddAsync(Clients);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<string> DeleteClientAsync(int Id)
        {
            var result = _dbContext.Clients.FirstOrDefault(x => x.Id == Id);
            _dbContext.Clients.Remove(result);
            _dbContext.SaveChanges();
            return "Client deleted successfully";
        }

        public async Task<Client> GetClientById(int Id)
        {
            var result = await _dbContext.Clients.FindAsync(Id);
            return result;
        }

        public async Task<List<Client>> GetClientListAsync()
        {
            var result = await _dbContext.Clients.ToListAsync();
            return result;
        }

        public Task<List<Client>> SearchClientListAsync(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> UpdateClientAsync(ClientViewModels request)
        {
            var Clients = _mapper.Map<Client>(request);           
            var result = _dbContext.Clients.Update(Clients);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
