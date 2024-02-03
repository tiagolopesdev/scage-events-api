using Microsoft.AspNetCore.Http;

namespace SCAGEEvents.Application.Extension
{
    public class ConvertFileExtension
    {
        public string Name { get; set; }
        public Stream Content { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }

        public string Extension
        {
            get
            {
                return Path.GetExtension(Name);
            }
        }

        public ConvertFileExtension()
        {
            Content = new MemoryStream();
        }

        public static async Task<Stream> NewFileConvert(IFormFile formFile)
        {
            ConvertFileExtension file = new()
            {
                ContentLength = formFile.Length,
                ContentType = formFile.ContentType,
                Name = formFile.FileName
            };
            await formFile.CopyToAsync(file.Content, new CancellationToken());
            return file.Content;
        }
    }
}
