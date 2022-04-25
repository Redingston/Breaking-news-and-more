using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Interfaces.Repositories
{
    public interface IRepository<T1, T2> where T1 : class
    {
        Task<IEnumerable<T1>> GetAllAsync(CancellationToken token);
        Task<T1> GetByIdAsync(T2 id);
        Task<T1> Insert(T1 entity);
        void Delete(T1 entity);
        Task<T1> FindFirstOrDefaultAsync(T2 id);
        T1 Update(T1 entity);
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}