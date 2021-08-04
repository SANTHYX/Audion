namespace Application.Dto.Identity
{
    public record GetJwtToken
    {
        public string AccessToken { get; set; }
        public string Refresh { get; set; }
    }
}
