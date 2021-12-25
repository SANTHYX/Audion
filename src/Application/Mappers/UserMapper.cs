using Application.Commons.Helpers;
using Application.Commons.Mappers;
using Application.Dto;
using Application.Dto.User;
using Core.Commons.Pagination;
using Core.Domain;
using System;
using System.Linq;

namespace Application.Mappers
{
    public class UserMapper : IUserMapper
    {
        private readonly IServerDetails _server;

        public UserMapper(IServerDetails server)
        {
            _server = server;
        }

        public GetUserDto MapTo<TOut>(User source) where TOut : GetUserDto
            => source is null ? null : new()
            {
                UserName = source.UserName,
                Email = source.Email,
                Profile = source.Profile == null ? null : new()
                {
                    FirstName = source.Profile.FirstName,
                    LastName = source.Profile.LastName,
                    City = source.Profile.City,
                    Country = source.Profile.Country,
                    Avatar = source.Profile.ImageId is null ? null
                        : new Uri($"{ _server.GetServerURL() }/Images/{ source.Profile.ImageId }")
                }
            };

        public PagedResponseDto<GetUserCollectionDto> MapTo<TOut>(Page<User> source)
            where TOut : PagedResponseDto<GetUserCollectionDto>
            => new()
            {
                Page = source.CurrentPage,
                Collection = source.Collection?.Select(x => new GetUserCollectionDto
                {
                    
                }),
                Results = source.Results,
                TotalPages = source.TotalPages,
                TotalResults = source.TotalResults
            };
    }
}
