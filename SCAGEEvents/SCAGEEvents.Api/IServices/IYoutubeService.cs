using Google.Apis.Upload;
using SCAGEEvents.Api.DTO;
using SCAGEEvents.Api.Model;

namespace SCAGEEvents.Api.IServices
{
    public interface IYoutubeService
    {
        public Task<UploadStatus> InsertThumbnailsLiveStream(InsertThumbnailsModel insertThumbnails);
        public Task<UploadStatus> CreateLiveStream(CreateLiveStreamDto request);
    }
}
