using Microsoft.AspNetCore.Http;

namespace Application.Dto.Profile.Requests
{
    public record UploadAvatarDto
    {
        public IFormFile Avatar { get; set; }
    }
}