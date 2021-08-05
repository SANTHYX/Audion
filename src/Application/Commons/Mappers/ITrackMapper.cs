using Application.Dto.Track;
using Core.Domain;
using System.Collections.Generic;

namespace Application.Commons.Mappers
{
    public interface ITrackMapper : IBaseMapper<GetTrackDto, Track>, 
        IBaseMapper<IEnumerable<GetTracksDto>, IEnumerable<Track>>
    {
    }
}
