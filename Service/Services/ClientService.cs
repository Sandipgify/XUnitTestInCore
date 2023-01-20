using Service.DTO;
using Service.Interface;
using Service.Mapping;
using Service.Repository;

namespace Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task Create(ClientDTO clientDTO, CancellationToken cancellationToken)
        {
            var client = ClientMapping.ToClient(clientDTO);
            await _clientRepository.Create(client,cancellationToken);
            await _clientRepository.SaveChanges();
        }
    }
}
