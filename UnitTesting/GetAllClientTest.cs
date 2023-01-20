using DomainModel.Model;

namespace Service.UnitTest;

public class GetAllClientTest
{
    private readonly Mock<IClientRepository> _clientRepositoryMock;
    private ClientService _clientService;
    public GetAllClientTest()
    {
        _clientRepositoryMock = new Mock<IClientRepository>();
        _clientService = new ClientService(_clientRepositoryMock.Object);
    }

    [Fact]

    public async Task Get_AllClient_Should_Succeed()
    {
        List<Client> clients = new List<Client>
        {
            new Client { Id = 1,
            Name = "John Doe",
            Description = "Test description",
            GenderId = 2,
            CreateDate = DateTime.Now},
            new Client { Id = 2,
            Name = "Test Name",
            Description = "Desc",
            GenderId = 1,
            CreateDate = DateTime.Now}
        };

        _clientRepositoryMock.Setup(x => x.Get(It.IsAny<CancellationToken>())).ReturnsAsync(clients);

        var response = await _clientService.Get(new CancellationToken());
        response.ShouldBeAssignableTo<IEnumerable<ClientDTO>>();
    }
}
