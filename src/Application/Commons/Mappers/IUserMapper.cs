using Application.Dto;
using Application.Dto.User;
using Core.Commons.Pagination;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface IUserMapper : IMapperWithRequestAccess<GetUserDto, User>
    {
    }
}
