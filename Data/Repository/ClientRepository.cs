using DomainModel.Model;
using Microsoft.Extensions.Logging;
using Service.Repository;

namespace Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ILogger<ClientRepository> _logger;
        private readonly ClientDBContext _clientDbContext;

        public ClientRepository(ILogger<ClientRepository> logger, ClientDBContext clientDbContext)
        {
            _logger = logger;
            _clientDbContext = clientDbContext;
        }
        public async Task SaveChanges() { await _clientDbContext.SaveChangesAsync();}
        public async Task Create(Client client, CancellationToken cancellationToken)
        {
            try
            {
                await _clientDbContext.AddAsync(client, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding client");
            }
        }
    }
}
