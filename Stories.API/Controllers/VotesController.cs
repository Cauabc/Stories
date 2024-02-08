using Microsoft.AspNetCore.Mvc;
using Stories.API.Application.Requests;
using Stories.Services.Services.Votes;
using System.Net;

namespace Stories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController(IVoteService service): ControllerBase
    {
        private readonly IVoteService _service = service;

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] VoteRequest request)
        {
            if (request.StoryId == Guid.Empty || request.AccountId == Guid.Empty)
                return BadRequest();

            if (_service.Create(request.StoryId, request.AccountId, request.Upvote))
                return Ok();
            
            return BadRequest();
        }
    }
}
