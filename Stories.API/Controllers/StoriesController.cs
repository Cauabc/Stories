using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stories.API.Application.ViewModels;
using Stories.API.Commands;
using Stories.API.Queries;
using Stories.API.Validators;
using Stories.Services.Services.Story;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Stories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController(IStoryService service, IMediator mediator, IValidator<UpdateStoryCommand> validator) : ControllerBase
    {
        private readonly IValidator<UpdateStoryCommand> _validator = validator;
        private readonly IStoryService _service = service;
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StoryViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllStoriesQuery();

            var response = await _mediator.Send(query);

            if (!response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(StoryViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById(Guid id, [FromServices] IValidator<GetStoryByIdQuery> validator)
        {

            var command = new GetStoryByIdQuery { Id = id };

            var result = await validator.ValidateAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            var response = await _mediator.Send(command);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateStoryCommand command, [FromServices] IValidator<CreateStoryCommand> validator)
        {
            var result = await validator.ValidateAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            var response = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id = response }, command);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteStoryCommand { Id = id };

            var response = await _mediator.Send(command);

            if (!response)
                return NotFound();

            return Ok();

        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(Guid id, string title, string description, string department)
        {

            var command = new UpdateStoryCommand { Id = id, Title = title, Description = description, Department = department };
            
            var result = await _validator.ValidateAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            var response = await _mediator.Send(command);

            if (response == null)
                return NotFound();

            if (!response.Value)
                return BadRequest();

            return Ok();


        }

        [HttpPost("{id:guid}/vote")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Vote(Guid id, [FromQuery] Guid accountId, [FromQuery] bool upvote)
        {
            bool storyExists = _service.GetById(id) != null;

            if (id == Guid.Empty || accountId == Guid.Empty)
                return BadRequest();

            if (!storyExists)
                return BadRequest();

            _service.PostVote(id, accountId, upvote);
            return Ok();
        }
    }
}
