using Cliente.Data;
using Cliente.Model;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Services
{
    public class ClientService : IClientService
    {
        private readonly DbContextClass _dbContext;

        public ClientService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Client> AddClient(Client client)
        {
            var result = _dbContext.Clients.Add(client);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteClient(int Id)
        {
            var client = _dbContext.Clients.Where(x => x.ClientId == Id).FirstOrDefaultAsync();
            var result = _dbContext.Remove(client);
            await _dbContext.SaveChangesAsync();
            return result != null;
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _dbContext.Clients.Where(x => x.ClientId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Client>> GetClientList()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<Client> UpdateClient(Client client)
        {
            var result = _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
