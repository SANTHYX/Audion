using Application.Commons.Mappers;
using Application.Dto.Track;
using Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    public class TrackMapper : ITrackMapper
    {
        public GetTrackDto MapTo(Track source)
            => source is null ? null : new()
            {

            };

        public IEnumerable<GetTracksDto> MapTo(IEnumerable<Track> source)
            => source.Select(x => new GetTracksDto
            {
                Title = x.Title
            });
    }
}
