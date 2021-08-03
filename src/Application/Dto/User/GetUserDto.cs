namespace Application.Dto.User
{
    public record GetUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
