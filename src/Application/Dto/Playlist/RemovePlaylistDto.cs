using System;
using System.Text.Json.Serialization;

namespace Application.Dto.Playlist
{
    public record RemovePlaylistDto
    {
        public Guid Id { get; set; }
    }
}
