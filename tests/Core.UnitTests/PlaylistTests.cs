using Core.Domain;
using Moq;

namespace Core.UnitTests
{
    public class PlaylistTests
    {
        private readonly Mock<Playlist> _playlistMock;

        public PlaylistTests()
        {
            _playlistMock = new();
        }
    }
}
