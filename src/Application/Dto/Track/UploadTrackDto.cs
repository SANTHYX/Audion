using Microsoft.AspNetCore.Http;

namespace Application.Dto.Track
{
    public record UploadTrackDto
    {
        public string Title { get; set; }
        public IFormFile Track { get; set; }
    }
}
