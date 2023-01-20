using DomainModel.Model;

namespace Service.Repository
{
    public interface IClientRepository
    {
        Task SaveChanges();
        Task Create(Client client, CancellationToken cancellationToken);
    }
}
