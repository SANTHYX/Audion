using Microsoft.AspNetCore.Http;

namespace Application.Dto.Track
{
    public record UploadTrackDto
    {
        public IFormFile Track { get; set; }
    }
}
