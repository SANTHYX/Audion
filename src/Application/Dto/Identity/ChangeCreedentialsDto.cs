namespace Application.Dto.Identity
{
    public record ChangeCreedentialsDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
