using Moq;
using Stories.Services.DTOs;
using Stories.Services.Services.Story;

namespace Stories.tests.Services
{
    public class StoryServiceTest
    {
        private readonly Mock<IStoryService> _service;

        public StoryServiceTest()
        {
            _service = new Mock<IStoryService>();
        }

        [Fact]
        public void GetAll_HasData_ReturnsData()
        {
            _service.Setup(s => s.GetAll()).Returns(new List<StoryDTO>() { new() });

            var result = _service.Object.GetAll();

            _service.Verify(s => s.GetAll(), Times.Once());

            Assert.IsAssignableFrom<IEnumerable<StoryDTO>>(result);
        }

        [Fact]
        public void GetAll_HasNoData_ReturnsEmpty()
        {
            _service.Setup(s => s.GetAll()).Returns(new List<StoryDTO>());

            var result = _service.Object.GetAll();

            _service.Verify(s => s.GetAll(), Times.Once());

            Assert.Empty(result);
        }

        [Fact]
        public void GetById_HasData_ReturnsData()
        {
            _service.Setup(s => s.GetById(It.IsAny<Guid>())).Returns(new StoryDTO());

            var result = _service.Object.GetById(Guid.NewGuid());

            _service.Verify(s => s.GetById(It.IsAny<Guid>()), Times.Once());

            Assert.IsAssignableFrom<StoryDTO>(result);
        }

        [Fact]
        public void GetById_HasNoData_ReturnsEmpty()
        {
            _service.Setup(s => s.GetById(It.IsAny<Guid>())).Returns((StoryDTO)null);

            var result = _service.Object.GetById(Guid.NewGuid());

            _service.Verify(s => s.GetById(It.IsAny<Guid>()), Times.Once());

            Assert.Null(result);
        }

        [Fact]
        public void Create_ValidData_ReturnsId()
        {
            _service.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Guid.NewGuid());

            var result = _service.Object.Create("Title", "Description", "Department");

            _service.Verify(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());

            Assert.IsType<Guid>(result);
        }

        [Fact]
        public void Create_InvalidData_ReturnsEmpty()
        {
            _service.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Guid.Empty);

            var result = _service.Object.Create("Title", "Description", "Department");

            _service.Verify(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());

            Assert.Equal(Guid.Empty, result);
        }


    }
}
