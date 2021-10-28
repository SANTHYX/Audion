using Application.Commons.Mappers;
using Application.Dto;
using Application.Dto.Track;
using Core.Commons.Pagination;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Application.Mappers
{
    public class TrackMapper : ITrackMapper
    {
        public GetTrackDto MapTo(Track source)
            => source is null ? null : new()
            {

            };

        public PagedResponseDto<GetTracksDto> MapTo(Page<Track> source, HttpContext context)
            => new()
            {
                Page = source.CurrentPage,
                Results = source.Results,
                Collection = source.Collection.Select(x => new GetTracksDto
                {
                    Title = x.Title,
                    TrackURL = new Uri($"{ context.Request.Host.Value }/Track/{ x.Id }")
                }),
                TotalResults = source.TotalResults,
                TotalPages = source.TotalPages
            };
    }
}
