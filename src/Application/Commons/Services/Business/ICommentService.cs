using Application.Commons.Types;
using Application.Dto.Comment;
using System.Threading.Tasks;

namespace Application.Commons.Services.Business
{
    public interface ICommentService : IService
    {
        Task CommentTrackAsync(AddCommentDto model);
        Task CommentPlaylistAsync(AddCommentDto model);
        Task EditTrackCommentAsync(EditCommentDto model);
        Task EditPlaylistCommentAsync(EditCommentDto model);
        Task ReplyToCommentAsync(ReplyCommentDto model);
    }
}
