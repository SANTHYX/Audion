using System;

namespace Core.Commons.Types
{
    public class AudiableEntity : Entity
    {
        public DateTime AddedAt { get; protected set; }
        public DateTime EditedAt { get; protected set; }

        public AudiableEntity()
        {
            AddedAt = EditedAt = DateTime.UtcNow;
        }
    }
}
