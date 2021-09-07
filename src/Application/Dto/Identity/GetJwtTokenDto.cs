namespace Application.Dto.Identity
{
    public record GetJwtTokenDto
    {
        public string AccessToken { get; set; }
        public string Refresh { get; set; }
        public string UserName { get; set; }
    }
}
