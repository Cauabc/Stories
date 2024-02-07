using Moq;
using Stories.Services.DTOs;
using Stories.Services.Services.Account;

namespace Stories.tests.Services;

public class AccountServiceTest
{
    private readonly Mock<IAccountService> _service;

    public AccountServiceTest()
    {
        _service = new Mock<IAccountService>();
    }

    [Fact]
    public void GetAll_HasData_ReturnsData()
    {
        _service.Setup(s => s.GetAll()).Returns(new List<AccountDTO>() { new() });

        var result = _service.Object.GetAll();

        _service.Verify(s => s.GetAll(), Times.Once());

        Assert.IsAssignableFrom<IEnumerable<AccountDTO>>(result);
    }

    [Fact]
    public void GetAll_HasNoData_ReturnsEmpty()
    {
        _service.Setup(s => s.GetAll()).Returns(new List<AccountDTO>());

        var result = _service.Object.GetAll();

        _service.Verify(s => s.GetAll(), Times.Once());

        Assert.Empty(result);
    }

    [Fact]
    public void Post_ValidData_ReturnsGuid()
    {
        _service.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>())).Returns(Guid.NewGuid());

        var result = _service.Object.Create("Test", "Test");

        _service.Verify(s => s.Create(It.IsAny<string>(), It.IsAny<string>()), Times.Once());

        Assert.IsType<Guid>(result);
    }

    [Fact]
    public void Post_InvalidData_ReturnsEmptyGuid()
    {
        _service.Setup(s => s.Create(null, "Jacaré")).Returns(Guid.Empty);

        var result = _service.Object.Create(null, "Jacaré");

        _service.Verify(s => s.Create(null, "Jacaré"), Times.Once());

        Assert.Equal(Guid.Empty, result);
    }

}
