using System;

namespace Application.Dto.Playlist.Responses
{
    public record GetPlaylistCollectionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
