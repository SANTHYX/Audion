using System;

namespace Application.Dto.Track
{
    public record GetTracksDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
