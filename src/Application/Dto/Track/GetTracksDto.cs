using System;

namespace Application.Dto.Track
{
    public record GetTracksDto
    {
        public string Title { get; set; }
        public Uri TrackURL { get; set; }
    }
}
