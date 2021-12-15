using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INewssRepository : IDisposable
    {
        IEnumerable<Domain.Entities.News> GetAllNews();
        Domain.Entities.News GetUserById(string userId);
        string CreateUser(Domain.Entities.News user);
        string DeleteUser(string userId);
        string UpdateUser(Domain.Entities.News user);
        int Save();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}