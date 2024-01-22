using Google.Apis.YouTube.v3.Data;
using SCAGEEvents.Api.DTO;
using SCAGEEvents.Api.VO;

namespace SCAGEEvents.Api.Build
{
    public static class LiveBroadcastBuild
    {
        public static LiveBroadcast BuildLiveBroadCast(CreateLiveStreamDto liveStreamDto)
        {
            return new LiveBroadcast()
            {
                Kind = "youtube#liveBroadcast",
                Snippet = BuildLiveBroadcastSnippet(liveStreamDto),
                Status = BuildLiveBroadcastStatus(liveStreamDto.Status)
            };
        }

        public static LiveBroadcastSnippet BuildLiveBroadcastSnippet(CreateLiveStreamDto liveStreamDto)
        {
            return new LiveBroadcastSnippet()
            {
                Title = liveStreamDto.Title,
                Description = liveStreamDto.Description,
                ChannelId = liveStreamDto.ChannelId,
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
