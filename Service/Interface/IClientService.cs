using Service.DTO;

namespace Service.Interface
{
    public interface IClientService
    {

        Task Create(ClientDTO clientDTO, CancellationToken cancellationToken);
    }
}
