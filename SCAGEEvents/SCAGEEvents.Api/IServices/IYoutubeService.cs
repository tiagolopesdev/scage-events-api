using SCAGEEvents.Api.DTO;

namespace SCAGEEvents.Api.IServices
{
    public interface IYoutubeService
    {
        public Task<string> CreateLiveStream(CreateLiveStreamDto request);
    }
}
