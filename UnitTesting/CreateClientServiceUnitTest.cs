namespace Service.UnitTest;

public class CreateClientServiceUnitTest
{
    private readonly Mock<IClientRepository> _clientRepositoryMock;
    private ClientService _clientServiceMock;

    public CreateClientServiceUnitTest()
    {
        _clientRepositoryMock = new();
        _clientServiceMock = new ClientService(_clientRepositoryMock.Object);
    }

    [Fact]
    public async Task Create_Client_Should_Succeed()
    {
        var clientDTO= new ClientDTO
        {
            Id = 1,
            Name = "John Doe",
            Description = "Test description",
            GenderId = 2
        };
        // Act
        await _clientServiceMock.Create(clientDTO,new CancellationToken());
        // Assert
        _clientRepositoryMock.Verify(x=>x.Create(It.Is<Client>(c=>

        c.Id == clientDTO.Id && c.Name == clientDTO.Name
            && c.Description == clientDTO.Description
            && c.GenderId == clientDTO.GenderId
            ),It.IsAny<CancellationToken>()), Times.Once);

        _clientRepositoryMock.Verify(x => x.SaveChanges(), Times.Once);
    }
}
