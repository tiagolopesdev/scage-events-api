using Google.Apis.YouTube.v3;
using SCAGEEvents.Api.Build;
using SCAGEEvents.Api.DTO;
using SCAGEEvents.Api.IServices;

namespace SCAGEEvents.Api.Service
{
    public class YoutubeServiceChannel : IYoutubeService
    {      
        public async Task<string> CreateLiveStream(CreateLiveStreamDto request)
        {
            try
            {
                YouTubeService service = new(await ConnectionGloogleService.ConnectGoogle());

                var objectBuilded = LiveBroadcastBuild.BuildLiveBroadCast(request);

                LiveBroadcastsResource.InsertRequest resourceToRequest = service.LiveBroadcasts.Insert(objectBuilded, "snippet,status");

                var result = await resourceToRequest.ExecuteAsync();

                //result.Id

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
