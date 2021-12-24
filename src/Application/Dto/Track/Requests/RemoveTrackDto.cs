using System;
using System.Text.Json.Serialization;

namespace Application.Dto.Track
{
    public record RemoveTrackDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
