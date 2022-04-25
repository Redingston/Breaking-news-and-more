using Application.Interfaces.Repositories;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class RefreshTokenRepository : IRepository<RefreshToken, string>
    {
        private ApplicationDbContext context;

        public RefreshTokenRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Delete(News entity)
        {
            context.Remove(entity);
        }

        public async Task<RefreshToken> FindFirstOrDefaultAsync(string id)
        {
            return await context.RefreshTokens.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<RefreshToken>> GetAllAsync(CancellationToken token)
        {
            return await context.RefreshTokens.ToListAsync(token);
        }

        public async Task<RefreshToken> GetByIdAsync(string id)
        {
            return await context.RefreshTokens.FindAsync(id);
        }

        public async Task<RefreshToken> Insert(RefreshToken entity)
        {
            await context.RefreshTokens.AddAsync(entity);
            return entity;
        }

        public async Task<int> SaveChangesAsync(CancellationToken token)
        {
            return await context.SaveChangesAsync(token);
        }

        public RefreshToken Update(RefreshToken entity)
        {
            context.RefreshTokens.Update(entity);
            return entity;
        }
    }
}