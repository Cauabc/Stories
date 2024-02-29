using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stories.API.Application.ViewModels;
using Stories.API.Commands;
using Stories.API.Queries;
using Stories.Services.Services.Account;
using System.Net;

namespace Stories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(IAccountService service, IMediator mediator) : ControllerBase
    {
        private readonly IAccountService _service = service;
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AccountViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get()
        {
            var command = new GetAllUsersQuery();

            var result = await _mediator.Send(command);

            if (result.Any())
                return Ok(result);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateAccountCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == Guid.Empty)
                return BadRequest();

            return CreatedAtAction(nameof(Get), new { id = response }, command);
        }
    }
}

