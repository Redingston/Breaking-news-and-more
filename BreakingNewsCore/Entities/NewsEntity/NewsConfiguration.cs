using BreakingNewsCore.Entities.CommentEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakingNewsCore.Entities.NewsEntity
{
    public class NewsConfiguration
    {public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Text)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}