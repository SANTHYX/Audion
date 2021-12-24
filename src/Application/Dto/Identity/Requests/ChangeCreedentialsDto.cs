namespace Application.Dto.Identity.Requests
{
    public record ChangeCreedentialsDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
