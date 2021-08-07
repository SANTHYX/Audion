using System;

namespace Core.Commons.Types
{
    public abstract class Entity
    {
        public Guid Id { get; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
