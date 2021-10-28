using Application.Dto;
using Application.Dto.Track;
using Core.Commons.Pagination;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface ITrackMapper : IMapper<GetTrackDto, Track>, 
        IMapperWithRequestAccess<PagedResponseDto<GetTracksDto>, Page<Track>>
    {
        
    }
}
