using Cliente.Exceptions;
using Cliente.Model;
using Cliente.Services;
using Microsoft.AspNetCore.Mvc;
using NotImplementedException = Cliente.Exceptions.NotImplementedException;

namespace Cliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientService clientService;
        private ILogger<ClienteController> _logger;
        public ClienteController(IClientService clientService, ILogger<ClienteController> logger)
        {
            this.clientService = clientService;
            _logger = logger;
        }

        [HttpGet("clientlist")]
        public Task<IEnumerable<Client>> ClientList()
        {
            var clientList = clientService.GetClientList();
            return clientList;
        }

        [HttpGet("obterclientporid")]
        public Task<Client> GetClientById(int Id)
        {
            _logger.LogInformation($"Buscando Client com ID: {Id} no banco de dados");
            var client = clientService.GetClientById(Id);
            if (client.Result == null)
            {
                throw new NotFoundException($"Product ID {Id} not found.");
            }
            _logger.LogInformation($"Retornando client com ID: {client.Result.ClientId}.");
            return client;
        }

        [HttpPost("addclient")]
        public Task<Client> AddClient(Client client)
        {
            return clientService.AddClient(client);
        }
        [HttpPut("updateclient")]
        public Task<Client> UpdateClient(Client client)
        {
            return clientService.UpdateClient(client);
        }
        [HttpDelete("deleteclient")]
        public Task<bool> DeleteClient(int Id)
        {
            return clientService.DeleteClient(Id);
        }
        [HttpGet("filtroclient")]
        public Task<List<Client>> FiltroCliente(int Id)
        {
            throw new NotImplementedException("Not Implemented Exception!");
        }

    }
}
