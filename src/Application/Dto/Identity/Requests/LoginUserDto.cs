namespace Application.Dto.Identity.Requests
{
    public record LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
