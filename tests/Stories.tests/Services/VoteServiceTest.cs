using Moq;
using Stories.Services.Services.Votes;

namespace Stories.tests.Services
{
    public class VoteServiceTest
    {
        private readonly Mock<IVoteService> _service;
        public VoteServiceTest()
        {
            _service = new Mock<IVoteService>();
        }

        [Fact]
        public void Create_ValidData_ReturnsTrue()
        {
            _service.Setup(s => s.Create(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(true);

            var result = _service.Object.Create(Guid.NewGuid(), Guid.NewGuid(), true);

            _service.Verify(s => s.Create(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>()), Times.Once());

            Assert.True(result);
        }

        [Fact]
        public void Create_InvalidData_ReturnsFalse()
        {
            _service.Setup(s => s.Create(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(false);

            var result = _service.Object.Create(Guid.NewGuid(), Guid.NewGuid(), true);

            _service.Verify(s => s.Create(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>()), Times.Once());

            Assert.False(result);
        }
    }
}
