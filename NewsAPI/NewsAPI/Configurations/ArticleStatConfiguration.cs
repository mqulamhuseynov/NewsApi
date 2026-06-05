using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsAPI.Entities;

namespace NewsAPI.Configurations
{
    public class ArticleStatsConfiguration : IEntityTypeConfiguration<ArticleStats>
    {
        public void Configure(EntityTypeBuilder<ArticleStats> builder)
        {
            builder.ToTable("article_stats");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ArticleId)
                   .HasColumnName("article_id");

            builder.Property(e => e.Likes)
                   .HasColumnName("likes_count")
                   .HasDefaultValue(0);

            builder.Property(e => e.Shares)
                   .HasColumnName("shares_count")
                   .HasDefaultValue(0);

            builder.Property(e => e.Bookmarks)
                   .HasColumnName("bookmarks_count")
                   .HasDefaultValue(0);

            builder.Property(e => e.Comments)
                   .HasColumnName("comments_count")
                   .HasDefaultValue(0);

            builder.HasOne(e => e.Article)
                   .WithOne(a => a.ArticleStats)
                   .HasForeignKey<ArticleStats>(e => e.ArticleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => e.ArticleId).IsUnique();
        }
    }
}
