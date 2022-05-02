using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakingNewsCore.Entities.NewsToCategoryEntity
{
    public class NewsToCategoryConfiguration : IEntityTypeConfiguration<NewsToCategory>
    {
        public void Configure(EntityTypeBuilder<NewsToCategory> builder)
        {
            builder.HasKey(e => new {e.CategoryId, e.NewsId});

            builder.HasOne(e => e.News)
                   .WithMany(e => e.Categories)
                   .HasForeignKey(e => e.NewsId)
                   .IsRequired();

            builder.HasOne(e => e.Category)
                   .WithMany(e => e.News)
                   .HasForeignKey(e => e.CategoryId)
                   .IsRequired();
        }
    }
}