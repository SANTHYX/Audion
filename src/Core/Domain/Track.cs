using Core.Commons.Types;
using System;

namespace Core.Domain
{
    public class Track : Entity
    {
        public string Title { get; private set; }
        public string TrackId { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        protected Track() { }

        public Track(string title, string trackId, User user)
        {
            SetTitle(title);
            SetTrack(trackId);
            AddUser(user);
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetTrack(string trackId)
        {
            TrackId = trackId ?? throw new ArgumentNullException(nameof(trackId),
                "Passed empty value of track name");
        }

        public void AddUser(User user)
        {
            User = user ?? throw new Exception("Cannot bind Track with empty User");
        }
    }
}
