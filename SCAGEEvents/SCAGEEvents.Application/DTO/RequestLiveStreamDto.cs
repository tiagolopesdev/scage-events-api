using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SCAGEEvents.Application.DTO
{
    public class RequestLiveStreamDto
    {
        [Required]
        public string Fields { get; set; }
        public IFormFile Thumbnails { get; set; }
    }
}
