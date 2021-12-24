using Core.Commons.Types;
using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Playlist : Entity
    {
        public string Name { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public IEnumerable<Track> Tracks { get; private set; }

        protected Playlist() { }

        public Playlist(string name, User user)
        {
            SetName(name);
            AddUser(user);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(name, "Name is required");
            }
            if (Name == name)
            {
                return;
            }

            Name = name;
        }

        public void AddUser(User user)
        {
            User = user ?? throw new ArgumentNullException
                (nameof(user), "Cannot bind newly Playlist with empty user");
        }
    }
}
