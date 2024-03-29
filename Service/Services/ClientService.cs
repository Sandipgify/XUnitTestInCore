﻿using Service.DTO;
using Service.Interface;
using Service.Mapping;
using Service.Repository;
using System.Threading;

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
            client.CreateDate = DateTime.UtcNow;
            await _clientRepository.Create(client, cancellationToken);
            await _clientRepository.SaveChanges();
        }

        public async Task Update(ClientDTO clientDTO, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = await _clientRepository.Get(clientDTO.Id, cancellationToken);

                if (client is null)
                    throw new Exception("Client is null");

                client.Description = clientDTO.Description;
                client.Name = clientDTO.Name;
                client.GenderId = clientDTO.GenderId;
                await _clientRepository.Update(client);
                await _clientRepository.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClientDTO> Get(long id, CancellationToken cancellationToken)
        {

            var client = await _clientRepository.Get(id, cancellationToken);
            var clientDTO = ClientMapping.ToClientDTO(client);
            return clientDTO;
        }

        public async Task<IEnumerable<ClientDTO>> Get(CancellationToken cancellationToken)
        {
            var client = (await _clientRepository.Get(cancellationToken)).ToList();
            return client.Select(c => c.ToClientDTO());
        }

        public async Task<bool> ClientExist(long id, CancellationToken cancellationToken)

        {
            return await _clientRepository.ClientExist(id, cancellationToken);
        }

        public async Task DeleteClient(long id, CancellationToken cancellationToken = default)

        {
            var client = await _clientRepository.Get(id, cancellationToken);
            if (client is null)
                throw new Exception("Client doesnot exist");
            await _clientRepository.Delete(id);
            await _clientRepository.SaveChanges();
        }
    }
}
