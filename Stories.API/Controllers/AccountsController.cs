using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stories.API.Application.ViewModels;
using Stories.Services.Services.Account;
using System.Net;

namespace Stories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(IAccountService service) : ControllerBase
    {
        private readonly IAccountService _service = service;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AccountViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Get()
        {
            var result = _service.GetAll().Select(s => new AccountViewModel { Id = s.Id, Name = s.Name, Email = s.Email });
            
            if (result.Any())
                return Ok(result);

            return NoContent();
        }
    }
}
