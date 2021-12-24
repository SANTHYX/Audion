using Core.Commons.Pagination;

namespace Application.Dto.User
{
    public record BrowseUsersQueryDto : PagedQuery
    {
        public string UserName { get; set; }
    }
}
