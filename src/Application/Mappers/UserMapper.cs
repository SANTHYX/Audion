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
            => new()
            {
                UserName = source.UserName,
                Email = source.Email,
                Profile = new()
                {
                    FirstName = source.Profile.FirstName,
                    LastName = source.Profile.LastName,
                    City = source.Profile.City,
                    Country = source.Profile.Country,
                    ImageId = new Uri($"{ context.Request.Host }/Images/{ source.Profile.ImageId }");
                }
            };      
    }
}
