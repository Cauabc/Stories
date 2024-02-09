using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Post(Guid storyId, Guid accountId, bool upvote)
        {
            if (storyId == Guid.Empty || accountId == Guid.Empty)
                return BadRequest();

            if (_service.Create(storyId, accountId, upvote))
                return Ok();
            
            return BadRequest();
        }
    }
}
