using Core.Domain;
using System;

namespace Application.Extensions.Validations.Profile
{
    public static class ProfileOwningValidation
    {
        public static User NotOwnProfile(this User user)
        {
            if (user.Profile is not null)
            {
                throw new Exception("User already have instance of profile");
            }

            return user;
        }
    }
}
