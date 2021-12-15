using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class NewsRepository : INewssRepository
    {
        private ApplicationDbContext context;
        public NewsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public  string CreateUser(News news)
        {

            return news.Id;
        }

        public string DeleteUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<News> GetAllNews()
        {
            throw new System.NotImplementedException();
        }

        public News GetUserById(string userId)
        {
            throw new System.NotImplementedException();
        }

        public int Save()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public string UpdateUser(News user)
        {
            throw new System.NotImplementedException();
        }
    }
}