using Google.Apis.Upload;
using Microsoft.AspNetCore.Mvc;
using SCAGEEvents.Api.DTO;
using SCAGEEvents.Api.IServices;
using System.Net;
using System.Text.Json;

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
        [Produces("multipart/form-data")]
        [ProducesResponseType(typeof(UploadStatus), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(UploadStatus), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLiveStream([FromForm] RequestLiveStreamDto request)
        {
            try
            {
                CreateLiveStreamDto buildObject = JsonSerializer.Deserialize<CreateLiveStreamDto>(request.Fields);

                buildObject.Thumbnails = request.Thumbnails;

                var eventCreated = await _youtubeService.CreateLiveStream(buildObject);

                return Ok(eventCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
