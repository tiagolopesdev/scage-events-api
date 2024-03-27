using Google.Apis.Upload;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Http;
using SCAGEEvents.Application.DTO;

namespace SCAGEEvents.Application.IServices
{
    public interface IYoutubeService
    {
        public Task<Guid> UpdateDay(string liveStream, Guid dayId);
        public Task<UploadStatus> InsertThumbnailsLiveStream(IFormFile formFile, string liveStreamId);
        public Task<string> CreateLiveStream(LiveStreamDto request);
        public Task<LiveBroadcast> GetLiveStreamById(string id);
        public Task<string> DeleteLiveStream(string id);
        public Task<string> UpdateLiveStream(LiveStreamDto buildObject);
    }
}
