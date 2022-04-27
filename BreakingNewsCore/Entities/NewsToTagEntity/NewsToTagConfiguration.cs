using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class NewsToTagConfiguration : IEntityTypeConfiguration<NewsToTag>
    {
        public void Configure(EntityTypeBuilder<NewsToTag> builder)
        {
            builder.HasKey(e => new {e.NewsId, e.TagId});

            builder.HasOne(e => e.News)
                   .WithMany(e => e.Tags)
                   .HasForeignKey(e => e.NewsId)
                   .IsRequired();

            builder.HasOne(e => e.Tag)
                   .WithMany(e => e.News)
                   .HasForeignKey(e => e.TagId)
                   .IsRequired();
        }
    }
}