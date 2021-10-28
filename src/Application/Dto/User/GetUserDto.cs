using Application.Dto.User.NestedModels;

namespace Application.Dto.User
{
    public record GetUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public ProfileModel Profile {  get; set; }
    }
}
