using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class PlaylistEntityConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(25)
                .IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(y => y.Playlists);
        }
    }
}
