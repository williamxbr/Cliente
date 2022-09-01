using Cliente.Model;

namespace Cliente.Services
{
    public interface IClientService
    {
        public Task<IEnumerable<Client>> GetClientList();
        public Task<Client> GetClientById(int id);
        public Task<Client> AddClient(Client client);
        public Task<Client> UpdateClient(Client client);
        public Task<bool> DeleteClient(int Id);

    }
}
