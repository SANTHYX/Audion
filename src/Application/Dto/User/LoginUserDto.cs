namespace Application.Dto.User
{
    public record LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
