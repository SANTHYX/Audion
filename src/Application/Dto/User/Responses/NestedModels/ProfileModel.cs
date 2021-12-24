using System;

namespace Application.Dto.Track.NestedModels
{
    public record ProfileModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Uri Avatar { get; set; }
    }
}
