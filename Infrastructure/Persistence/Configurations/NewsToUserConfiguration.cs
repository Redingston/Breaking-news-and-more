using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class NewsToUserConfiguration : IEntityTypeConfiguration<NewsToUser>
    {
        public void Configure(EntityTypeBuilder<NewsToUser> builder)
        {
            builder.HasKey(e => new {e.NewsId, e.UserId});

            builder.HasOne(e => e.News)
                   .WithMany(e => e.Users)
                   .HasForeignKey(e => e.NewsId)
                   .IsRequired();

            builder.HasOne(e => e.User)
                   .WithMany(e => e.News)
                   .HasForeignKey(e => e.UserId)
                   .IsRequired();
        }
    }
}