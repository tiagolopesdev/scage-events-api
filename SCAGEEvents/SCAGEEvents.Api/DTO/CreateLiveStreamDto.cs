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
/*
{
    "kind": "youtube#liveBroadcast",
    "snippet": {
        "scheduledStartTime": "2024-01-22T19:00:00",
        "channelId": "UCYuiMRv-pAEcPcqPAuUl_wg",
        "title": "Test create live stream",
        "description": "Description test live stream",
        "thumbnails": {
            "default": {
                "url": "https://drive.google.com/file/d/1VCK74_DkpkqwKI9yptvJhCScEBxh_wf2/view?usp=drive_link",
                "width": 120,
                "height": 90
            },
            "medium": {
                "url": "https://drive.google.com/file/d/1VCK74_DkpkqwKI9yptvJhCScEBxh_wf2/view?usp=drive_link",
                "width": 320,
                "height": 180
            },
            "high": {
                "url": "https://drive.google.com/file/d/1VCK74_DkpkqwKI9yptvJhCScEBxh_wf2/view?usp=drive_link",
                "width": 480,
                "height": 360
            }
        }
    },
    "status": {
        "privacyStatus": "unlisted"
    }
}
 */
