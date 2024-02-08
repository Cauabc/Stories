using Microsoft.AspNetCore.Mvc;
using Moq;
using Stories.API.Controllers;
using Stories.Services.Services.Votes;

namespace Stories.tests.Controllers;

public class VotesControllerTest
{
    private readonly Mock<IVoteService> _service;
    private readonly VotesController _controller;
    public VotesControllerTest()
    {
        _service = new Mock<IVoteService>();
        _controller = new VotesController(_service.Object);
    }

    [Fact]
    public void Post_ValidData_ReturnsOk()
    {
        _service.Setup(s => s.Create(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(true);

        var result = _controller.Post(Guid.NewGuid(), Guid.NewGuid(), true);

        _service.Verify(s => s.Create(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>()), Times.Once());

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void Post_InvalidData_ReturnsBadRequest()
    {
        _service.Setup(s => s.Create(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(false);

        var result = _controller.Post(Guid.NewGuid(), Guid.NewGuid(), true);

        _service.Verify(s => s.Create(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>()), Times.Once());

        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public void Post_EmptyData_ReturnsBadRequest()
    {
        var result = _controller.Post(Guid.Empty, Guid.Empty, false);

        _service.Verify(s => s.Create(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>()), Times.Never());

        Assert.IsType<BadRequestResult>(result);
    }
}
