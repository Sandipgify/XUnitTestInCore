using DomainModel.Model;

namespace Service.Repository
{
    public interface IClientRepository
    {
        Task SaveChanges();
        Task Create(Client client, CancellationToken cancellationToken);
        Task Update(Client client);
        Task<Client> Get(long id, CancellationToken cancellationToken);
        Task<IEnumerable<Client>> Get(CancellationToken cancellationToken);
        Task Delete(long id);
        Task<bool> ClientExist(long id, CancellationToken cancellationToken);
    }
}
