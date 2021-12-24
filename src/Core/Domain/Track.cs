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
            SetTrackId(trackId);
            AddUser(user);
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Title is required");
            }
            if (Title == title)
            {
                return;
            }

            Title = title;
        }

        public void SetTrackId(string trackId)
        {
            if (string.IsNullOrWhiteSpace(trackId))
            {
                throw new ArgumentNullException
                    (nameof(trackId), "Passed empty value of track name");
            }
            if (TrackId == trackId)
            {
                return;
            }

            TrackId = trackId;
        }

        public void AddUser(User user)
        {
            User = user ?? throw new ArgumentNullException("Cannot bind Track with empty User");
        }
    }
}
