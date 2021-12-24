namespace Application.Dto.Identity.Requests
{
    public record RegisterUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
