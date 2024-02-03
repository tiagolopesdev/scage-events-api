using Microsoft.AspNetCore.Mvc;
using SCAGEEvents.Api.DTO;
using SCAGEEvents.Api.IServices;
using SCAGEEvents.Api.Utils;
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

        [HttpGet("GetLiveById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest, "application/json")]
        public async Task<IActionResult> CreateLiveStream([FromQuery] string id)
        {
            try
            {
                var eventCreated = await _youtubeService.GetLiveStreamById(id);

                return Ok(ResponseApi.New("Live criada com sucesso", eventCreated));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateLiveStream")]
        [Produces("multipart/form-data", "application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest, "application/json")]
        public async Task<IActionResult> CreateLiveStream([FromForm] RequestLiveStreamDto request)
        {
            try
            {
                LiveStreamDto buildObject = JsonSerializer.Deserialize<LiveStreamDto>(request.Fields);

                buildObject.Thumbnails = request.Thumbnails;

                string eventCreated = await _youtubeService.CreateLiveStream(buildObject);

                return Ok(ResponseApi.New("Live criada com sucesso", eventCreated));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateLiveStream")]
        [Produces("multipart/form-data", "application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest, "application/json")]
        public async Task<IActionResult> UpdateLiveStream([FromForm] RequestLiveStreamDto request)
        {
            try
            {
                LiveStreamDto buildObject = JsonSerializer.Deserialize<LiveStreamDto>(request.Fields);

                buildObject.Thumbnails = request.Thumbnails;

                string eventCreated = await _youtubeService.UpdateLiveStream(buildObject);

                return Ok(ResponseApi.New("Live atualizada com sucesso", eventCreated));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteLiveStream")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound, "application/json")]
        public async Task<IActionResult> DeleteLiveStream([FromQuery] string id)
        {
            try
            {
                string eventCreated = await _youtubeService.DeleteLiveStream(id);

                return Ok(ResponseApi.New("Live excluída com sucesso", eventCreated));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
