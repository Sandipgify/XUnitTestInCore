namespace Service.UnitTest;

public class GetClientByIdUnitTest
{
    private readonly Mock<IClientRepository> _clientRepositoryMock;
    private ClientService _serviceMock;
    public GetClientByIdUnitTest()
    {
        _clientRepositoryMock= new Mock<IClientRepository>();
        _serviceMock = new ClientService(_clientRepositoryMock.Object);
    }


    [Fact]
    public async Task GetClient_Should_Succeed()
    {
        #region Setup

        var client = new Client
        {
            Id = 1,
            Name = "John Doe",
            Description = "Test description",
            GenderId = 2,
            CreateDate = DateTime.Now
        };

        _clientRepositoryMock.Setup(x => x.Get(It.IsAny<long>(), It.IsAny<CancellationToken>())).ReturnsAsync(client);
        #endregion

        long clientId = 2; //Random ClientId
        var response = await _serviceMock.Get(clientId, new CancellationToken());
        response.ShouldBeOfType<ClientDTO>();
        
    }
}
