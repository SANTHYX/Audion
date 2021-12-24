using System;

namespace Application.Dto.Playlist.Requests
{
    public record RemovePlaylistDto
    {
        public Guid Id { get; set; }
    }
}
