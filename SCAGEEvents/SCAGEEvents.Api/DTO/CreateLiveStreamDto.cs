using SCAGEEvents.Api.VO;
using System.Text.Json.Serialization;

namespace SCAGEEvents.Api.DTO
{
    public class CreateLiveStreamDto
    {
        [JsonIgnore]
        public string? ChannelId { get; set; }  
        public DateTime ScheduledStartTime { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public StatusLive Status { get; set; }  
        //public FileStream Thumbnails { get; set; }  
    }
}
