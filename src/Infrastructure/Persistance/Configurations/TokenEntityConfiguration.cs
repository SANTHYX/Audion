using Core.Commons.Identity;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class TokenEntityConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasKey(x => x.RefreshToken);
            builder.Property(x => x.IsRevoked)
                .HasMaxLength(2);
            builder.Property(x => x.CreatedAt)
                .HasMaxLength(15);
            builder.Property(x => x.ExpiresAt)
                .HasMaxLength(15);
            builder.HasOne(x => x.User)
                .WithMany(y=>y.Tokens);
        }
    }
}
