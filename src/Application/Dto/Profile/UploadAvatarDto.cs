using Microsoft.AspNetCore.Http;

namespace Application.Dto.Profile
{
    public record UploadAvatarDto
    {
        public IFormFile Avatar { get; set; }
    }
}