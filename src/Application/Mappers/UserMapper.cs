using Application.Commons.Mappers;
using Application.Dto.User;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using System;

namespace Application.Mappers
{
    public class UserMapper : IUserMapper
    {
        public GetUserDto MapTo(User source, HttpContext context)
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
                    ImageId = source.Profile.ImageId is null ? null : 
                        new Uri($"{ context.Request.Host }/Images/{ source.Profile.ImageId }")
                }
            };      
    }
}
