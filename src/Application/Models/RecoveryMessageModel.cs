using System;

namespace Application.Models
{
    public record RecoveryMessageModel
    {
        public Uri BaseUrl { get; set; }
        public Guid RecoveryId { get; set; }
    }
}
