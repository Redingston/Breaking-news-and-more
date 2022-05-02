using System.Reflection;
using BreakingNewsCore.Entities.CategoryEntity;
using BreakingNewsCore.Entities.CommentEntity;
using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Entities.NewsToCategoryEntity;
using BreakingNewsCore.Entities.NewsToReactionEntity;
using BreakingNewsCore.Entities.NewsToTagEntity;
using BreakingNewsCore.Entities.NewsToUserEntity;
using BreakingNewsCore.Entities.ReactionEntity;
using BreakingNewsCore.Entities.UserEntity;
using BreakingNewsCore.Entities.RefreshTokenEntity;
using BreakingNewsCore.Entities.RoleEntity;
using BreakingNewsCore.Entities.TagEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<News> BreakingNews { get; set; }
        public DbSet<NewsToCategory> NewsToCategories { get; set; }
        public DbSet<NewsToReaction> NewsToReactions { get; set; }
        public DbSet<NewsToTag> NewsToTags { get; set; }
        public DbSet<NewsToUser> NewsToUsers { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new NewsToCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new NewsToReactionConfiguration());
            modelBuilder.ApplyConfiguration(new NewsToTagConfiguration());
            modelBuilder.ApplyConfiguration(new NewsToUserConfiguration());
            modelBuilder.ApplyConfiguration(new ReactionConfiguration());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityRoleConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
