using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Maps
{
    public class ProfileEntityConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .HasMaxLength(30);
            builder.Property(x => x.LastName)
                .HasMaxLength(35);
            builder.Property(x => x.Country)
                .HasMaxLength(15);
            builder.Property(x => x.City)
                .HasMaxLength(30);
            builder.Property(x => x.ImageId)
                .HasMaxLength(30);
        }
    }
}
