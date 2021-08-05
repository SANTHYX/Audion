using Application.Commons.Mappers;
using Application.Dto.Track;
using Core.Domain;

namespace Application.Mappers
{
    public class TrackMapper : ITrackMapper
    {
        public GetTrackDto MapTo(Track source)
            => source is null ? null : new()
            {

            };
    }
}
