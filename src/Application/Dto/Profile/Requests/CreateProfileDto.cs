namespace Application.Dto.Profile.Requests
{
    public record CreateProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
