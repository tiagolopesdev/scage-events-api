using Google.Apis.Upload;
using SCAGEEvents.Api.DTO;

namespace SCAGEEvents.Api.IServices
{
    public interface IYoutubeService
    {
        public Task<UploadStatus> InsertThumbnailsLiveStream(IFormFile formFile, string liveStreamId);
        public Task<string> CreateLiveStream(CreateLiveStreamDto request);
    }
}
