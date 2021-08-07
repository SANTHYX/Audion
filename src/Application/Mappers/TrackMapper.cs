using Application.Commons.Mappers;
using Application.Dto;
using Application.Dto.Track;
using Core.Commons.Pagination;
using Core.Domain;
using System.Linq;

namespace Application.Mappers
{
    public class TrackMapper : ITrackMapper
    {
        public GetTrackDto MapTo(Track source)
            => source is null ? null : new()
            {

            };

        public PagedResponseDto<GetTracksDto> MapTo(Page<Track> source)
            => new()
            {
                Page = source.CurrentPage,
                Results = source.Results,
                Collection = source.Collection.Select(x => new GetTracksDto
                {
                    Title = x.Title
                }),
                TotalResults = source.TotalResults,
                TotalPages = source.TotalPages
            };
    }
}
