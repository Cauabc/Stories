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
}
