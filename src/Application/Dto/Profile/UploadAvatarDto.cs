using Microsoft.AspNetCore.Http;

namespace Application.Dto.Profile
{
    public record UploadAvatarDto
    {
        IFormFile Avatar { get; set; }
    }
}