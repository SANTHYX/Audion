using Application.Commons.Types;
using Application.Dto;
using Application.Dto.User;
using Core.Commons.Pagination;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface IUserMapper : IMapper<GetUserDto, User>,
        IMapper<PagedResponseDto<GetUserCollectionDto>, Page<User>>
    {
    }
}
