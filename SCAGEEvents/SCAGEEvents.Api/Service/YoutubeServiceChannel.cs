using Google.Apis.Upload;
using Google.Apis.YouTube.v3;
using SCAGEEvents.Api.Build;
using SCAGEEvents.Api.DTO;
using SCAGEEvents.Api.Extension;
using SCAGEEvents.Api.IServices;
using SCAGEEvents.Api.Model;

namespace SCAGEEvents.Api.Service
{
    public class YoutubeServiceChannel : IYoutubeService
    {
        public async Task<UploadStatus> CreateLiveStream(CreateLiveStreamDto request)
        {
            try
            {
                YouTubeService service = new(await ConnectionGloogleService.ConnectGoogle());

                var objectBuilded = LiveBroadcastBuild.BuildLiveBroadCast(request);

                LiveBroadcastsResource.InsertRequest resourceToRequest = service.LiveBroadcasts.Insert(objectBuilded, "snippet,status");

                var result = await resourceToRequest.ExecuteAsync();

                var thumbnails = new InsertThumbnailsModel()
                {
                    LiveStreamId = result.Id,
                    Thumbnails = request.Thumbnails,
                    ContentTypeThumbnails = ManipulationFileExtension.CheckExtensionFile(request.Thumbnails)
                };

                return await InsertThumbnailsLiveStream(thumbnails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UploadStatus> InsertThumbnailsLiveStream(InsertThumbnailsModel insertThumbnails)
        {
            try
            {
                YouTubeService service = new(await ConnectionGloogleService.ConnectGoogle());

                Stream fileConverted = await ConvertFileExtension.NewFileConvert(insertThumbnails.Thumbnails);

                ThumbnailsResource.SetMediaUpload setMediaUpload = service.Thumbnails.Set(
                    insertThumbnails.LiveStreamId,
                    fileConverted,
                    insertThumbnails.ContentTypeThumbnails
                    );

                var result = await setMediaUpload.UploadAsync();

                return result.Status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
