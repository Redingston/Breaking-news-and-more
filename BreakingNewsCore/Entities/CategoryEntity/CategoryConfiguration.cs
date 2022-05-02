using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakingNewsCore.Entities.CategoryEntity
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasData(
                new Category()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Top news"
                },
                new Category()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Sports"
                },
                new Category()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Science"
                },
                new Category()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Technology"
                }, new Category()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Movies"
                },
                new Category()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Game's news"
                }
            );
        }
    }
}