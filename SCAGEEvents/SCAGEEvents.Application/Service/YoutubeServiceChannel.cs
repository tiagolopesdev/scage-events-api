using Google.Apis.Upload;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SCAGEEvents.Application.Build;
using SCAGEEvents.Application.DTO;
using SCAGEEvents.Application.Extension;
using SCAGEEvents.Application.IServices;

namespace SCAGEEvents.Application.Service
{
    public class YoutubeServiceChannel : IYoutubeService
    {
        private readonly IConfiguration _configuration;

        public YoutubeServiceChannel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreateLiveStream(LiveStreamDto request)
        {
            try
            {
                YouTubeService service = new(await ConnectionGloogleService.ConnectGoogle());

                var objectBuilded = new LiveBroadcastBuild(_configuration).BuildLiveBroadCast(request);

                LiveBroadcastsResource.InsertRequest resourceToRequest = service.LiveBroadcasts.Insert(objectBuilded, "snippet,status");

                var result = await resourceToRequest.ExecuteAsync();

                InsertThumbnailsLiveStream(request.Thumbnails, result.Id);

                return result.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteLiveStream(string id)
        {
            try
            {
                YouTubeService service = new(await ConnectionGloogleService.ConnectGoogle());

                LiveBroadcastsResource.DeleteRequest resourceToRequest = service.LiveBroadcasts.Delete(id);

                return await resourceToRequest.ExecuteAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LiveBroadcast> GetLiveStreamById(string id)
        {
            try
            {
                YouTubeService service = new(await ConnectionGloogleService.ConnectGoogle());


                LiveBroadcastsResource.ListRequest resourceToRequest = service.LiveBroadcasts.List("id,snippet,status");

                resourceToRequest.Id = id;

                var result = await resourceToRequest.ExecuteAsync();

                return result.Items.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> UpdateLiveStream(LiveStreamDto request)
        {
            try
            {
                YouTubeService service = new(await ConnectionGloogleService.ConnectGoogle());

                var objectBuilded = new LiveBroadcastBuild(_configuration).BuildLiveBroadCast(request);

                LiveBroadcastsResource.UpdateRequest resourceToRequest = service.LiveBroadcasts.Update(objectBuilded, "id,snippet,status");

                var result = await resourceToRequest.ExecuteAsync();

                InsertThumbnailsLiveStream(request.Thumbnails, result.Id);

                return result.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UploadStatus> InsertThumbnailsLiveStream(IFormFile formFile, string liveStreamId)
        {
            try
            {
                YouTubeService service = new(await ConnectionGloogleService.ConnectGoogle());

                Stream fileConverted = await ConvertFileExtension.NewFileConvert(formFile);

                string extensionChecked = CheckExtensionFile.CheckThumbnailsExtension(formFile);

                ThumbnailsResource.SetMediaUpload setMediaUpload = service.Thumbnails.Set(
                    liveStreamId,
                    fileConverted,
                    extensionChecked
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
