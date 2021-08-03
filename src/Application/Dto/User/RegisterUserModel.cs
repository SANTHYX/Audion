namespace Application.Dto.User
{
    public record RegisterUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
