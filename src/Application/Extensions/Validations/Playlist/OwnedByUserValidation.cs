using System;

namespace Application.Extensions.Validations.Playlist
{
    public static class OwnedByUserValidation
    {
        public static Core.Domain.Playlist OwnedByCurrentUser(this Core.Domain.Playlist playlist, Guid userId)
        {
            if (playlist.UserId != userId)
            {
                throw new Exception("You are not authorized to perform that action");
            }

            return playlist;
        }
    }
}
