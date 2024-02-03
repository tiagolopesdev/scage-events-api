using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Configuration;
using SCAGEEvents.Application.DTO;
using SCAGEEvents.Application.VO;

namespace SCAGEEvents.Application.Extension
{
    public class LiveBroadcastBuild
    {
        private readonly string ChannelIdEnviroment;

        public LiveBroadcastBuild(IConfiguration configuration)
        {
            ChannelIdEnviroment = configuration.GetValue<string>("YoutubeEnviroments:ChannelId");
        }

        public LiveBroadcast BuildLiveBroadCast(LiveStreamDto liveStreamDto)
        {
            var objectToReturn = new LiveBroadcast()
            {
                Kind = "youtube#liveBroadcast",
                Snippet = BuildLiveBroadcastSnippet(liveStreamDto),
                Status = BuildLiveBroadcastStatus(liveStreamDto.Status)
            };

            if (!string.IsNullOrEmpty(liveStreamDto.Id)) objectToReturn.Id = liveStreamDto.Id;

            return objectToReturn;
        }

        public LiveBroadcastSnippet BuildLiveBroadcastSnippet(LiveStreamDto liveStreamDto)
        {
            return new LiveBroadcastSnippet()
            {
                Title = liveStreamDto.Title,
                Description = liveStreamDto.Description,
                ChannelId = ChannelIdEnviroment,
                ScheduledStartTime = liveStreamDto.ScheduledStartTime
            };
        }

        public static LiveBroadcastStatus BuildLiveBroadcastStatus(StatusLive statusLive)
        {
            LiveBroadcastStatus broadcastStatus = new LiveBroadcastStatus();

            switch (statusLive)
            {
                case StatusLive.PUBLIC: broadcastStatus.PrivacyStatus = "public"; break;
                case StatusLive.UNLISTED: broadcastStatus.PrivacyStatus = "unlisted"; break;
                case StatusLive.PRIVATE: broadcastStatus.PrivacyStatus = "private"; break;
            }

            return broadcastStatus;
        }
    }
}
