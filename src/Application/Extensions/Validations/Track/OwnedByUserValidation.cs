using System;

namespace Application.Extensions.Validations.Track
{
    public static class OwnedByUserValidation
    {
        public static Core.Domain.Track OwnedByCurrentUser(this Core.Domain.Track track, Guid userId)
        {
            if (track.UserId != userId)
            {
                throw new Exception("You are not authorized to perform that action");
            }

            return track;
        }
    }
}
