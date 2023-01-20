using DomainModel.Model;
using Microsoft.EntityFrameworkCore;
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
        public async Task SaveChanges() { await _clientDbContext.SaveChangesAsync(); }
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

        public async Task Update(Client client)
        {
            try
            {
                await Task.FromResult(_clientDbContext.Update(client));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating client");
            }
        }


        public async Task<Client> Get(long id, CancellationToken cancellationToken)
        {
            try
            {
                return await _clientDbContext.Clients.FindAsync(id, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while Getting by id");
                throw;
            }
        }

        public async Task<IEnumerable<Client>> Get(CancellationToken cancellationToken)
        {
            try
            {
                return await _clientDbContext.Clients.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting client");
                throw;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                await Task.FromResult(_clientDbContext.Remove(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting client");
            }
        }

        public async Task<bool> ClientExist(long id,CancellationToken cancellationToken)
        {
            try
            {
                return await _clientDbContext.Clients.AnyAsync(x=>x.Id==id,cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting client");
                throw;
            }
        }
    }
}
