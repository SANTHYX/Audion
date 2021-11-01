using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json.Serialization;

namespace Application.Dto.Track
{
    public record UploadTrackDto
    {
        public string Title { get; set; }
        public IFormFile Track { get; set; }
    }
}
