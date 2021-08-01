using Core.Types;
using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Playlist : Entity
    {
        public string Name { get; private set; }
        public IEnumerable<Track> Tracks { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
    }
}
