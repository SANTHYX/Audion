using Application.Commons.Helpers;
using Application.Commons.Mappers;
using Application.Dto;
using Application.Dto.Track;
using Core.Commons.Pagination;
using Core.Domain;
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

        public GetTrackDto MapTo<TOut>(Track source) where TOut : GetTrackDto
            => source is null ? null : new()
            {
                
            };

        public PagedResponseDto<GetTracksDto> MapTo<TOut>(Page<Track> source) 
            where TOut : PagedResponseDto<GetTracksDto>
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
