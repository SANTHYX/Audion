using Core.Commons.Types;
using System;

namespace Core.Domain
{
    public class Track : Entity
    {
        public string Title { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        protected Track() { }

        public Track(string title, User user)
        {
            Title = title;
            AddUser(user);
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void AddUser(User user)
        {
            User = user ?? throw new Exception("Cannot bind newly Track with empty user");
        }
    }
}
