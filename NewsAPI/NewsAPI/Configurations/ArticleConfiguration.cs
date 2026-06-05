using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsAPI.Entities;

namespace NewsAPI.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("articles");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                   .HasColumnName("title")
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(e => e.ShortDescription)
                   .HasColumnName("short_description")
                   .HasColumnType("NVARCHAR(MAX)")
                   .IsRequired();

            builder.Property(e => e.Content)
                   .HasColumnName("content")
                   .HasColumnType("NVARCHAR(MAX)")
                   .IsRequired();

            builder.Property(e => e.ImageUrl)
                   .HasColumnName("image_url")
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(e => e.CategoryId)
                   .HasColumnName("category_id");

            builder.Property(e => e.AuthorId)
                   .HasColumnName("author_id");

            builder.Property(e => e.ReadTimeMinutes)
                   .HasColumnName("read_time_minutes")
                   .IsRequired();

            builder.Property(e => e.IsTrending)
                   .HasColumnName("is_trending")
                   .HasDefaultValue(false);

            builder.Property(e => e.IsBreaking)
                   .HasColumnName("is_breaking")
                   .HasDefaultValue(false);

            builder.Property(e => e.IsLive)
                   .HasColumnName("is_live")
                   .HasDefaultValue(false);

            builder.Property(e => e.IsEditorsPick)
                   .HasColumnName("is_editors_pick")
                   .HasDefaultValue(false);

            builder.Property(e => e.IsFeatured)
                   .HasColumnName("is_featured")
                   .HasDefaultValue(false);

            builder.Property(e => e.CreatedAt)
                   .HasColumnName("created_at")
                   .IsRequired();

            //relation
            builder.HasOne(e => e.Category)
                   .WithMany(c => c.Articles)
                   .HasForeignKey(e => e.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Author)
                   .WithMany(a => a.Articles)
                   .HasForeignKey(e => e.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
