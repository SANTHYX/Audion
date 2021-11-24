using System;
using System.Text.Json.Serialization;

namespace Application.Dto.Playlist
{
    public record DeletePlaylistDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
