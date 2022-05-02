using BreakingNewsCore.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Entities.NewsEntity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class NewsRepository : IRepository<News, string>
    {
        private ApplicationDbContext context;

        public NewsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(News entity)
        {
            context.Remove(entity);
        }

        public async Task<News> FindFirstOrDefaultAsync(string id)
        {
            return await context.BreakingNews.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<News>> GetAllAsync(CancellationToken token)
        {
            return await context.BreakingNews.ToListAsync(token);
        }

        public async Task<News> GetByIdAsync(string id)
        {
            return await context.BreakingNews.FindAsync(id);
        }

        public async Task<News> Insert(News entity)
        {
            await context.BreakingNews.AddAsync(entity);
            return entity;
        }

        public async Task<int> SaveChangesAsync(CancellationToken token)
        {
           return await context.SaveChangesAsync(token);
        }

        public News Update(News entity)
        {
            context.BreakingNews.Update(entity);
            return entity;
        }
    }
}