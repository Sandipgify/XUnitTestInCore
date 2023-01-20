using Service.DTO;

namespace Service.UnitTest;

public class DeleteClientServiceUnitTest
{
    private readonly Mock<IClientRepository> _clientRepositoryMock;
    private ClientService _clientServiceMock;

    public DeleteClientServiceUnitTest()
    {
        _clientRepositoryMock = new Mock<IClientRepository>();
        _clientServiceMock = new ClientService(_clientRepositoryMock.Object);
    }

    [Fact]
    public async Task DeleteClientService_Should_Succeed()

    {
        var client = new Client
        {
            Id = 1,
            Name = "John Doe",
            Description = "Test description",
            GenderId = 2,
            CreateDate = DateTime.Now
        };

        _clientRepositoryMock.Setup(x => x.Get(It.IsAny<long>(), It.IsAny<CancellationToken>())).ReturnsAsync(client);

        long clientId = 25;

        // act
        await _clientServiceMock.DeleteClient(clientId);
        //Assert
        _clientRepositoryMock.Verify(x => x.Delete(It.IsAny<long>()), Times.Once);

        _clientRepositoryMock.Verify(x => x.SaveChanges(), Times.Once);
    }


    [Fact]
    public async Task DeleteClientService_Should_ThrowException_WhenClientIsNull()

    {
        _clientRepositoryMock.Setup(x => x.Get(It.IsAny<long>(), It.IsAny<CancellationToken>())).ReturnsAsync((Client)null);

        long clientId = 25;
        var assertion =() => _clientServiceMock.DeleteClient(clientId);
       var exception = Assert.ThrowsAsync<Exception>(assertion);

        exception.Result.Message.ShouldBe("Client doesnot exist");
    }

}
