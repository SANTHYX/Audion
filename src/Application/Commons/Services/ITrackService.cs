using Application.Dto;
using Application.Dto.Track;
using Core.Commons.Pagination;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface ITrackService
    {
        Task UploadAsync(UploadTrackDto model);
        Task<GetTrackDto> GetAsync(string title);
        Task<PagedResponseDto<GetTracksDto>> BrowseAsync(PagedQuery query);
    }
}
