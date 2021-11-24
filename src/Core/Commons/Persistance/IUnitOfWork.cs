using Core.Commons.Persistance.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Commons.Persistance
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; set; }
        IProfileRepository Profile { get; set; }
        ITokenRepository Token { get; set; }
        ITrackRepository Track { get; set; }
        IPlaylistRepository Playlist { get; set; }
        Task CommitAsync(CancellationToken token);
        Task CommitAsync();

    }
}
