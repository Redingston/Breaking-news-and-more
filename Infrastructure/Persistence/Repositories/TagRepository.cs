using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Entities.TagEntity;
using BreakingNewsCore.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TagRepository : IRepository<Tag, string>
    {
        private ApplicationDbContext context;

        public TagRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Tag entity)
        {
            context.Remove(entity);
        }

        public async Task<Tag> FindFirstOrDefaultAsync(string id)
        {
            return await context.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Tag>> GetAllAsync(CancellationToken token)
        {
            return await context.Tags.ToListAsync(token);
        }

        public async Task<Tag> GetByIdAsync(string id)
        {
            return await context.Tags.FindAsync(id);
        }

        public async Task<Tag> Insert(Tag entity)
        {
            await context.Tags.AddAsync(entity);
            return entity;
        }

        public async Task<int> SaveChangesAsync(CancellationToken token)
        {
           return await context.SaveChangesAsync(token);
        }

        public Tag Update(Tag entity)
        {
            context.Tags.Update(entity);
            return entity;
        }
    }
}