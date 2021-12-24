using System;

namespace Application.Dto.Track
{
    public record GetTrackCollectionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
