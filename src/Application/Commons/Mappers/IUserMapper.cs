using Application.Commons.Types;
using Application.Dto.User;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface IUserMapper : IMapper<GetUserDto, User>
    {
    }
}
