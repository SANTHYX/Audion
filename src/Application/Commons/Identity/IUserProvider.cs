using System;

namespace Application.Commons.Identity
{
    public interface IUserProvider
    {
        public Guid CurrentUserId { get; }
    }
}
