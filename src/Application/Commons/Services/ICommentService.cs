using Application.Commons.Types;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface ICommentService : IService
    {
        Task AddCommentAsync();
        Task EditCommentAsync();
    }
}
