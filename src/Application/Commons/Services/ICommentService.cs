using Application.Commons.Types;
using Application.Dto.Comment;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface ICommentService : IService
    {
        Task AddCommentAsync(AddCommentDto model);
        Task EditCommentAsync(EditCommentDto model);
    }
}
