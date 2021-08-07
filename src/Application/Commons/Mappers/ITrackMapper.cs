using Application.Dto;
using Application.Dto.Track;
using Core.Commons.Pagination;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface ITrackMapper : IBaseMapper<GetTrackDto, Track>, 
        IBaseMapper<PagedResponseDto<GetTracksDto>, Page<Track>>
    {
    }
}
