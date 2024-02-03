using System.ComponentModel.DataAnnotations;

namespace SCAGEEvents.Api.DTO
{
    public class RequestLiveStreamDto
    {
        [Required]
        public string Fields { get; set; }
        public IFormFile Thumbnails { get; set; }
    }
}
