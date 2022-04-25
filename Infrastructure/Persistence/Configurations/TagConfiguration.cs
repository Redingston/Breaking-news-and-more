using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(e => e.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.Color)
                   .HasMaxLength(7);

            builder.HasData(
                new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Popular",
                    Color = "#FFD133"
                },
                new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Education",
                    Color = "#33BBFF"
                },
                new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Unbelievable",
                    Color = "#6833FF"
                },
                new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Useful",
                    Color = "#07BA1F"
                },
                new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Issue",
                    Color = "#000000"
                },
                new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Non Popular",
                    Color = "#FF0000"
                }
            );
        }
    }
}