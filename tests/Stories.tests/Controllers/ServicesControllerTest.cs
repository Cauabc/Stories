using Microsoft.AspNetCore.Mvc;
using Moq;
using Stories.API.Controllers;
using Stories.Services.DTOs;
using Stories.Services.Services.Story;

namespace Stories.tests.Controllers
{
    public class ServicesControllerTest
    {
        private readonly Mock<IStoryService> _service;
        private readonly StoriesController _controller;
        public ServicesControllerTest()
        {
            _service = new Mock<IStoryService>();
            _controller = new StoriesController(_service.Object);
        }

        [Fact]
        public void GetAll_HasData_ReturnsOkObjectResult()
        {
            _service.Setup(s => s.GetAll()).Returns(new List<StoryDTO> { new() });

            var result = _controller.Get();

            _service.Verify(s => s.GetAll(), Times.Once);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAll_HasNoData_ReturnsNoContent()
        {
            _service.Setup(s => s.GetAll()).Returns(new List<StoryDTO>());

            var result = _controller.Get();

            _service.Verify(s => s.GetAll(), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetById_IdFound_ReturnsOkObjectResult()
        {
            var mockId = Guid.NewGuid();
            _service.Setup(s => s.GetById(mockId)).Returns(new StoryDTO());

            var result = _controller.GetById(mockId);

            _service.Verify(s => s.GetById(mockId), Times.Once);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_IdNotFound_ReturnsNotFound()
        {
            var mockId = Guid.NewGuid();

            _service.Setup(s => s.GetById(mockId)).Returns((StoryDTO)null);

            var result = _controller.GetById(mockId);

            _service.Verify(s => s.GetById(mockId), Times.Once);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Post_ValidData_ReturnsCreated()
        {
            _service.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Guid.NewGuid());

            var result = _controller.Post("Title", "Description", "Department");

            _service.Verify(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);

            Assert.IsType<CreatedAtActionResult>(result);       
        }

        [Fact]
        public void Post_EmptyData_ReturnsBadRequest()
        {
            var result = _controller.Post("", "", "");

            _service.Verify(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Post_InvalidData_ReturnsBadRequest()
        {
            _service.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Guid.Empty);

            var result = _controller.Post("Title", "Description", "Department");

            _service.Verify(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
