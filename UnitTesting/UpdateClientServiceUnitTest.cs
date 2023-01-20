namespace Service.UnitTest;

public class UpdateClientServiceUnitTest
{
    private readonly Mock<IClientRepository> _clientRepositoryMock;
    private readonly ClientService _clientService;

    public UpdateClientServiceUnitTest()
    {
        _clientRepositoryMock = new();
        _clientService = new ClientService(_clientRepositoryMock.Object);
    }

    public void ServiceSetup()
    {

        #region Arrange
        var client = new Client
        {
            Id = 1,
            Name = "John Doe",
            Description = "Test description",
            GenderId = 2,
            CreateDate = DateTime.Now
        };
        #endregion

        #region Setup
        // make a setup only if you are using the retrive value
        _clientRepositoryMock.Setup(x => x.Get(It.IsAny<long>(), It.IsAny<CancellationToken>())).ReturnsAsync(client);
        #endregion
    }

    [Fact]
    public async Task Update_Should_UpdateClientAndSaveChanges()
    {
        ServiceSetup();
        var clientDTO = new ClientDTO
        {
            Id = 1,
            Name = "John Doe",
            Description = "Test description",
            GenderId = 2
        };

        // Act
        await _clientService.Update(clientDTO, new CancellationToken());

        //Assert
        _clientRepositoryMock.Verify(x => x.Update(It.Is<Client>(c =>
            c.Id == clientDTO.Id && c.Name == clientDTO.Name
            && c.Description == clientDTO.Description
            && c.GenderId == clientDTO.GenderId
            )), Times.Once);

        _clientRepositoryMock.Verify(x => x.SaveChanges(), Times.Once);

    }

    [Fact]
    public async Task Update_Should_ThrowNullException_When_ClientNotExist()
    {
        _clientRepositoryMock.Setup(x => x.Get(It.IsAny<long>(), It.IsAny<CancellationToken>())).ReturnsAsync((Client)null);

        var clientDTO = new ClientDTO
        {
            Id = 1,
            Name = "John Doe",
            Description = "Test description",
            GenderId = 2
        };

        var assertion = () => _clientService.Update(clientDTO);
        var exception = Assert.ThrowsAsync<Exception>(assertion);
        exception.Result.Message.ShouldBe("Client is null");
    }
}

