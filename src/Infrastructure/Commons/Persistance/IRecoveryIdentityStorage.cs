using Core.Commons.Identity;
using System.Collections.Generic;

namespace Infrastructure.Commons.Persistance
{
    public interface IRecoveryIdentityStorage
    {
        ICollection<RecoveryIdentity> RecoveryIdentities { get; }
    }
}
