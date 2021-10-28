using Core.Domain;
using System;

namespace Application.Extensions.Validations.Profile
{
    public static class ProfileNotOwningValidation
    {
        public static User OwnProfile(this User user)
        {
            if (user.Profile is null)
            {
                throw new Exception("User dont own profile instance");
            }

            return user;
        }
    }
}
