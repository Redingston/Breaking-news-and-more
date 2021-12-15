using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Domain.Entities.News> BreakingNews { get; set; }
        DbSet<NewsToCategory> NewsToCategories { get; set; }
        DbSet<NewsToReaction> NewsToReactions { get; set; }
        DbSet<NewsToTag> NewsToTags { get; set; }
        DbSet<NewsToUser> NewsToUsers { get; set; }
        DbSet<Reaction> Reactions { get; set; }
        DbSet<Tag> Tags { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}