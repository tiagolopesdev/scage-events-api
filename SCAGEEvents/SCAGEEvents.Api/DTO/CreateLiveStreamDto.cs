using SCAGEEvents.Api.VO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SCAGEEvents.Api.DTO
{
    public class RequestLiveStreamDto
    {
        [Required]
        public string Fields { get; set; }
        public IFormFile Thumbnails { get; set; }
    }
    public class CreateLiveStreamDto
    {
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
