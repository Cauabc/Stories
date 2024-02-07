using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stories.API.Application.ViewModels;
using Stories.Services.Services.Story;
using System.Net;
using System.Net.Sockets;

namespace Stories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController(IStoryService service) : ControllerBase
    {
        private readonly IStoryService _service = service;

        // POST: api/Stories
        // PUT: api/Stories/{id}
        // DELETE: api/Stories/{id}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StoryViewModel>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Get()
        {
            var result = _service.GetAll().Select(s => new StoryViewModel { Id = s.Id, Title = s.Title, Description = s.Description, Department = s.Department, Likes = s.Likes, Dislikes = s.Dislikes});

            if (result.Any())
                return Ok(result);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StoryViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetById(Guid id)
        {
            var result = _service.GetById(id);

            if (result == null)
                return NotFound();

            var response = new StoryViewModel { Id = result.Id, Title = result.Title, Description = result.Description, Department = result.Department, Likes = result.Likes, Dislikes = result.Dislikes };

            return Ok(response);
        }
    }
}
