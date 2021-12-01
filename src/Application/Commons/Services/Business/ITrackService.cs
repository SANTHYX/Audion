﻿using Application.Commons.Types;
using Application.Dto;
using Application.Dto.Track;
using System.Threading.Tasks;

namespace Application.Commons.Services.Business
{
    public interface ITrackService : IService
    {
        Task<GetTrackDto> GetAsync(string title);
        Task<PagedResponseDto<GetTracksDto>> BrowseAsync(BrowseTracksQueryDto query);
        Task UploadAsync(UploadTrackDto model);
        Task RemoveAsync(RemoveTrackDto model);
    }
}
