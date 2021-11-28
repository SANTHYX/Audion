using Core.Commons.Types;
using Core.Domain;
using System;

namespace Core.Commons.Identity
{
    public class RecoveryIdentity : Entity
    {
        public User User { get; private set; }

        protected RecoveryIdentity()
        {

        }

        public RecoveryIdentity(User user)
        {
            AddUser(user);
        }

        public void AddUser(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user),
                "Cannot perform creedentials recovery on empty user");
        }
    }
}
