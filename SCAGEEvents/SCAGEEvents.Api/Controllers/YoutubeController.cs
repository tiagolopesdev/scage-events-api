using Microsoft.AspNetCore.Mvc;
using SCAGEEvents.Api.DTO;
using SCAGEEvents.Api.IServices;

namespace SCAGEEvents.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        private readonly IYoutubeService _youtubeService;

        public YoutubeController(IYoutubeService youtubeService)
        {
            _youtubeService = youtubeService;
        }

        [HttpPost("CreateLiveStream")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateLiveStream([FromBody] CreateLiveStreamDto request)
        {
            try
            {
                var eventCreated = await _youtubeService.CreateLiveStream(request);

                return Ok(eventCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
