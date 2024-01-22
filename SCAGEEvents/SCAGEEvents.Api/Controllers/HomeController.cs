using Microsoft.AspNetCore.Mvc;

namespace SCAGEEvents.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Index() => new RedirectResult("~/swagger");
    }
}
