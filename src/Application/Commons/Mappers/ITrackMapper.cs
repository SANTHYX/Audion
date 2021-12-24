using Application.Commons.Types;
using Application.Dto;
using Application.Dto.Track;
using Core.Commons.Pagination;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface ITrackMapper : IMapper<GetTrackDto, Track>,
        IMapper<PagedResponseDto<GetTrackCollectionDto>, Page<Track>>
    {

    }
}
