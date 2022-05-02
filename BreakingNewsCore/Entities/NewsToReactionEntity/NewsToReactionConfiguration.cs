using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakingNewsCore.Entities.NewsToReactionEntity
{
    public class NewsToReactionConfiguration : IEntityTypeConfiguration<NewsToReaction>
    {
        public void Configure(EntityTypeBuilder<NewsToReaction> builder)
        {
            builder.HasKey(e => new {e.NewsId, e.ReactionId});

            builder.HasOne(e => e.News)
                   .WithMany(e => e.Reactions)
                   .HasForeignKey(e => e.NewsId)
                   .IsRequired();

            builder.HasOne(e => e.Reaction)
                   .WithMany(e => e.BreakingNews)
                   .HasForeignKey(e => e.ReactionId)
                   .IsRequired();
        }
    }
}