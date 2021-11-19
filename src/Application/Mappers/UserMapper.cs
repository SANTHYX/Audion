using Application.Commons.Helpers;
using Application.Commons.Mappers;
using Application.Dto.User;
using Core.Domain;
using System;

namespace Application.Mappers
{
    public class UserMapper : IUserMapper
    {
        private readonly IServerDetails _server;

        public UserMapper(IServerDetails server)
        {
            _server = server;
        }

        public GetUserDto MapTo(User source)
            => source is null ? null :new()
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
    }
}
