using Application.Commons.Types;
using Application.Dto;
using Application.Dto.User;
using System.Threading.Tasks;

namespace Application.Commons.Services.Business
{
    public interface IUserService : IService
    {
        Task<GetUserDto> GetAsync(string userName);
        Task<PagedResponseDto<GetUserCollectionDto>> BrowseAsync(BrowseUsersQueryDto query);
    }
}
