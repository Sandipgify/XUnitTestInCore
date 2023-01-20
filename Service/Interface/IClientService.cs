using Service.DTO;

namespace Service.Interface
{
    public interface IClientService
    {

        Task Create(ClientDTO clientDTO, CancellationToken cancellationToken);
        Task Update(ClientDTO clientDTO, CancellationToken cancellationToken = default);
        Task<ClientDTO> Get(long id, CancellationToken cancellationToken);
        Task<IEnumerable<ClientDTO>> Get(CancellationToken cancellationToken);
        Task DeleteClient(long id);
        Task<bool> ClientExist(long id, CancellationToken cancellationToken);
    }
}
