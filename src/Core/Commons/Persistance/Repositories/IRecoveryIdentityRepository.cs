using Core.Commons.Identity;
using Core.Commons.Types;
using System;

namespace Core.Commons.Persistance.Repositories
{
    public interface IRecoveryIdentityRepository : IInMemoryRepository
    {
        RecoveryIdentity Get(Guid id);
        void Add(RecoveryIdentity recovery);
        void Remove(RecoveryIdentity recovery);
    }
}
