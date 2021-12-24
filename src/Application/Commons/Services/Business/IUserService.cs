using Application.Commons.Types;
using Application.Dto;
using Application.Dto.User;
using Core.Commons.Pagination;
using System.Threading.Tasks;

namespace Application.Commons.Services.Business
{
    public interface IUserService : IService
    {
        Task<GetUserDto> GetAsync(string userName);
        Task<PagedResponseDto<GetUserCollectionDto>> BrowseAsync(PagedQuery query);
    }
}
