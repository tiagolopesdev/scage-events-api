namespace SCAGEEvents.Api.Model
{
    public class InsertThumbnailsModel
    {
        public string LiveStreamId { get; set; }
        public IFormFile Thumbnails { get; set; }
        public string ContentTypeThumbnails { get; set; }
    }
}
