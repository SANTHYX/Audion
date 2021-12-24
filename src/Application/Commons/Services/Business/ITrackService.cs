using Application.Commons.Types;
using Application.Dto;
using Application.Dto.Track;
using System;
using System.Threading.Tasks;

namespace Application.Commons.Services.Business
{
    public interface ITrackService : IService
    {
        Task<GetTrackDto> GetAsync(Guid id);
        Task<PagedResponseDto<GetTrackCollectionDto>> BrowseAsync(BrowseTracksQueryDto query);
        Task UploadAsync(UploadTrackDto model);
        Task RemoveAsync(RemoveTrackDto model);
    }
}
