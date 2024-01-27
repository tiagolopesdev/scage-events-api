using Google.Apis.Upload;
using Google.Apis.YouTube.v3.Data;
using SCAGEEvents.Api.DTO;

namespace SCAGEEvents.Api.IServices
{
    public interface IYoutubeService
    {
        public Task<UploadStatus> InsertThumbnailsLiveStream(IFormFile formFile, string liveStreamId);
        public Task<string> CreateLiveStream(CreateLiveStreamDto request);
        public Task<LiveBroadcast> GetLiveStreamById(string id);
    }
}
