using Core.Commons.Types;
using Core.Domain;

namespace Core.Commons.Persistance.Repositories
{
    public interface ICommentRepository : IRepository, IGenericRepository<Comment>
    {
    }
}
