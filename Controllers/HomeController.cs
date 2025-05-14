using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskingOutAppAPI.Controllers
{
    //HealthCheck route
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
