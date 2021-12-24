using System;

namespace Application.Dto.Playlist.Requests
{
    public record UpdatePlaylistDto
    {
        public Guid Id { get; set; }
    }
}
