using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Maps
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName)
                .HasMaxLength(35)
                .IsRequired();
            builder.Property(x => x.Password)
                .HasMaxLength(70)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(40)
                .IsRequired();
            builder.HasOne(x => x.Profile)
                .WithOne(z => z.User)
                .HasForeignKey<Profile>(q => q.UserId);
            builder.HasMany(x => x.Tokens)
                .WithOne(y => y.User)
                .HasForeignKey(q => q.UserId);
            builder.HasMany(x => x.Playlists)
                .WithOne(y => y.User)
                .HasForeignKey(q => q.UserId);
        }
    }
}
