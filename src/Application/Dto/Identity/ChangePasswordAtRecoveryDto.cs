using System;
using System.Text.Json.Serialization;

namespace Application.Dto.Identity
{
    public record ChangePasswordAtRecoveryDto
    {
        [JsonIgnore]
        public Guid RecoveryId { get; set; }
        public string NewPassword { get; set; }
    }
}
