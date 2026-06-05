using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsAPI.Entities;

namespace NewsAPI.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .HasColumnName("name")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.Slug)
                   .HasColumnName("slug")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasIndex(e => e.Slug).IsUnique();

            builder.Property(e => e.BadgeColor)
                   .HasColumnName("badge_color")
                   .HasMaxLength(20);

            builder.HasMany(e => e.Articles)
                   .WithOne(a => a.Category)
                   .HasForeignKey(a => a.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
