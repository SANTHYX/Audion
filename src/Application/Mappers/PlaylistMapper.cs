using Application.Commons.Mappers;
using Application.Dto;
using Application.Dto.Playlist.Responses;
using Core.Commons.Pagination;
using Core.Domain;
using System.Linq;

namespace Application.Mappers
{
    public class PlaylistMapper : IPlaylistMapper
    {
        public GetPlaylistDto MapTo<TOut>(Playlist source) where TOut : GetPlaylistDto
            => source is null ? null : new()
            {

            };

        public PagedResponseDto<GetPlaylistCollectionDto> MapTo<TOut>(Page<Playlist> source)
            where TOut : PagedResponseDto<GetPlaylistCollectionDto>
            => source is null ? null : new()
            {
                Page = source.CurrentPage,
                Results = source.Results,
                TotalPages = source.TotalPages,
                TotalResults = source.TotalResults,
                Collection = source.Collection?.Select(x => new GetPlaylistCollectionDto
                {
                    Name = x.Name
                }),
            };

    }
}
