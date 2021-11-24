using Core.Commons.Identity;
using Core.Commons.Persistance.Repositories;
using Infrastructure.Commons.Persistance;
using System;
using System.Linq;

namespace Infrastructure.Persistance.Repositories
{
    public class RecoveryIdentityRepository : IRecoveryIdentityRepository
    {
        private readonly IRecoveryIdentityStorage _storage;

        public RecoveryIdentityRepository(IRecoveryIdentityStorage storage)
        {
            _storage = storage;
        }

        public RecoveryIdentity Get(Guid id)
            => _storage.RecoveryIdentities.FirstOrDefault(x => x.Id == id);

        public void Add(RecoveryIdentity recovery)
        {
            _storage.RecoveryIdentities.Add(recovery);
        }

        public void Remove(RecoveryIdentity recovery)
        {
            _storage.RecoveryIdentities.Remove(recovery);
        }
    }
}
