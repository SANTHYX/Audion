using Application.Commons.Mappers;
using Application.Dto.User;
using Core.Domain;

namespace Application.Mappers
{
    public class UserMapper : IUserMapper
    {
        public GetUserDto MapTo(User source)
            => source is null ? null : new()
            {
                UserName = source.UserName,
                Email = source.Email
            };
    }
}
