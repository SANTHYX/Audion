using Core.Domain;
using Moq;

namespace Core.UnitTests
{
    public class TrackTests
    {
        private readonly Mock<Track> _trackMock;

        public TrackTests()
        {
            _trackMock = new();
        }
    }
}
