using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hello", "World" };
        }

        [HttpGet("/welcome")]
        public string GetString()
        {
            return "Hello World, Welcome to CommandAPI";
        }
    }
}