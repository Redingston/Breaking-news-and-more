using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
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
       //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //Task<string> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
