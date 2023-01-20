using DomainModel.Model;
using Service.DTO;

namespace Service.Mapping
{
    public static class ClientMapping
    {
        public static Client ToClient(this ClientDTO client)

        {
            return new Client
            {

                Id = client.Id,
                Name = client.Name,
                Description = client.Description,
                GenderId = client.GenderId

            };
        }

        public static ClientDTO ToClientDTO(this Client client)

        {
            return new ClientDTO
            {

                Id = client.Id,
                Name = client.Name,
                Description = client.Description,
                GenderId = client.GenderId

            };
        }
    }
}
 