using DomainModel.Model;
using Microsoft.Extensions.Logging;

namespace Data.Repository
{
    public class ClientRepository
    {
        private readonly ILogger<ClientRepository> _logger;
        private readonly ClientDBContext _clientDbContext;

        public ClientRepository(ILogger<ClientRepository> logger, ClientDBContext clientDbContext)
        {
            _logger = logger;
            _clientDbContext = clientDbContext;
        }
        public async Task Create(Client client, CancellationToken cancellationToken)
        {
            await _clientDbContext.AddAsync(client,cancellationToken);
        }
    }
}
