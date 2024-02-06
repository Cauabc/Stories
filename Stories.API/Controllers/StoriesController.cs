using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Stories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        // GET: api/Stories
        // POST: api/Stories
        // PUT: api/Stories/{id}
        // DELETE: api/Stories/{id}
        // GETBYID: api/Stories/{id}

        [HttpGet]
        public string Get()
        {
            return "Deu";
        }
    }
}
