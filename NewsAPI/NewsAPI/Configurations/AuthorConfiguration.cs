using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsAPI.Entities;

namespace NewsAPI.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .HasColumnName("name")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.AvatarUrl)
                   .HasColumnName("avatar_url")
                   .HasMaxLength(500);

            builder.Property(e => e.Bio)
                   .HasColumnName("bio")
                   .HasColumnType("NVARCHAR(MAX)");

            builder.Property(e => e.TwitterHandle)
                   .HasColumnName("twitter_handle")
                   .HasMaxLength(50);

            builder.HasMany(e => e.Articles)
                   .WithOne(a => a.Author)
                   .HasForeignKey(a => a.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
