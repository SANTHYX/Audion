namespace Application.Dto.User
{
    public record LoginUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
