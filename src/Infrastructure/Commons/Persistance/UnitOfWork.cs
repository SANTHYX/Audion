using Core.Commons.Pagination;
using Core.Commons.Persistance;
using Core.Commons.Persistance.Repositories;
using Core.Domain;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; set; }
        public IProfileRepository Profile { get; set; }
        public ITokenRepository Token { get; set; }
        public ITrackRepository Track { get; set; }
        public IPlaylistRepository Playlist { get; set; }
        public ICommentRepository Comment { get; set; }
        private readonly DataContext _context;

        public UnitOfWork(DataContext context,
            IPagedResponse<Track> _trackResponse, 
            IPagedResponse<Playlist> _playlistResponse)
        {
            _context = context;
            User = new UserRepository(context);
            Profile = new ProfileRepository(context);
            Token = new TokenRepository(context);
            Track = new TrackRepository(context,_trackResponse);
            Playlist = new PlaylistRepository(context, _playlistResponse);
            Comment = new CommentRepository(context);
        }

        public async Task CommitAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
