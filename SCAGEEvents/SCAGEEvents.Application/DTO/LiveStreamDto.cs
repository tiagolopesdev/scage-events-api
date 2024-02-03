using Microsoft.AspNetCore.Http;
using SCAGEEvents.Application.VO;
using System.Text.Json.Serialization;

namespace SCAGEEvents.Application.DTO
{
    public class LiveStreamDto
    {
        [JsonPropertyName(name: "id")]
        public string? Id { get; set; }
        [JsonPropertyName(name: "scheduledStartTime")]
        public DateTime ScheduledStartTime { get; set; }
        [JsonPropertyName(name: "title")]
        public string Title { get; set; }
        [JsonPropertyName(name: "description")]
        public string? Description { get; set; }
        [JsonPropertyName(name: "status")]
        public StatusLive Status { get; set; }
        [JsonIgnore]
        public IFormFile Thumbnails { get; set; }
    }
}
