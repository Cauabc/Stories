using Microsoft.AspNetCore.Mvc;
using Stories.API.Application.ViewModels;
using Stories.Services.Services.Story;
using System.Net;

namespace Stories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController(IStoryService service) : ControllerBase
    {
        private readonly IStoryService _service = service;

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

        [HttpGet("{id:guid}")]
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

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post(string title, string description, string department)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(department))
                return BadRequest();

            var resultId = _service.Create(title, description, department);

            if (resultId == Guid.Empty)
                return BadRequest();

            return CreatedAtAction(nameof(Get), new { id = resultId }, new StoryViewModel { Id = resultId, Title = title, Description = description, Department = department });
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete(Guid id)
        {
            if (_service.Delete(id))
                return Ok();

            return NotFound();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Put(Guid id, string title, string description, string department)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(department))
                return BadRequest();

            if (_service.Update(id, title, description, department))
                return Ok();

            return NotFound();
        }
    }
}
