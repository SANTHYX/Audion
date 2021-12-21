using System;

namespace Application.Dto.Track
{
    public record GetTrackDto
    {
        public string Title { get; set; }
        public Uri Track { get; set; }
    }
}
