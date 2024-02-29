﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stories.API.Application.ViewModels;
using Stories.API.Commands.Requests;
using Stories.API.Handlers;
using Stories.API.Queries;
using Stories.API.Queries.Requests;
using Stories.API.Queries.Responses;
using Stories.Services.Services.Story;
using System.Net;

namespace Stories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController(IStoryService service, IMediator mediator) : ControllerBase
    {
        private readonly IStoryService _service = service;
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StoryViewModel>),(int)HttpStatusCode.OK)]
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
        [ProducesResponseType(typeof(FindStoryByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new FindStoryByIdRequest { Id = id };

            var response = await _mediator.Send(command);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody]CreateStoryRequest command)
        {
            var response = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteStoryByIdRequest { Id = id };

            var response = await _mediator.Send(command);

            if (!response.IsSucceded)
                return NotFound();

            return Ok();
                
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(Guid id, string title, string description, string department)
        {
            var command = new UpdateStoryRequest { Id = id, Title = title, Description = description, Department = department };

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
