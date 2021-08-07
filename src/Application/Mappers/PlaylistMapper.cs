using Application.Commons.Mappers;
using Application.Dto;
using Application.Dto.Playlist;
using Core.Commons.Pagination;
using Core.Domain;
using System.Linq;

namespace Application.Mappers
{
    public class PlaylistMapper : IPlaylistMapper
    {
        public GetPlaylistDto MapTo(Playlist source)
            => source is null ? null : new()
            {

            };

        public PagedResponseDto<GetPlaylistsDto> MapTo(IPagedResponse<Playlist> source)
            => source is null ? null : new()
            {
                Page = source.Page,
                Results = source.Results,
                TotalPages = source.TotalPages,
                TotalResults = source.TotalResults,
                Collection = source.Collection.Select(x => new GetPlaylistsDto
                {
                   Name = x.Name
                }),
            };
            
    }
}
