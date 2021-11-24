using Core.Commons.Identity;
using Infrastructure.Commons.Persistance;
using System.Collections.Generic;

namespace Infrastructure.Persistance
{
    //TODO: in future at the end of develop process it can be better to make this class as InMemoryDb
    public class RecoveryIdentityStorage : IRecoveryIdentityStorage
    {
        public ICollection<RecoveryIdentity> RecoveryIdentities { get; }

        public RecoveryIdentityStorage(ICollection<RecoveryIdentity> _recoveryIdentities)
        {
            RecoveryIdentities = _recoveryIdentities;
        }
    }
}
