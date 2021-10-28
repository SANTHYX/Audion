using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json.Serialization;

namespace Application.Dto.Track
{
    public record UploadTrackDto
    {
        [JsonIgnore]
        public Guid TrackId { get; set; }
        public string Title { get; set; }
        public IFormFile Track { get; set; }
    }
}
