using Application.Commons.Helpers;
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
        private readonly IServerDetails _server;

        public TrackMapper(IServerDetails server)
        {
            _server = server;
        }

        public GetTrackDto MapTo(Track source)
            => source is null ? null : new()
            {
                
            };

        public PagedResponseDto<GetTracksDto> MapTo(Page<Track> source)
            => new()
            {
                Page = source.CurrentPage,
                Results = source.Results,
                Collection = source.Collection?.Select(x => new GetTracksDto
                {
                    Title = x.Title,
                    Track = new Uri($"{ _server.GetServerURL() }/Track/{ x.Id }")
                }),
                TotalResults = source.TotalResults,
                TotalPages = source.TotalPages
            };
    }
}
