using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserById(string userId);
        void CreateUser(User user);
        void DeleteUser(string userId);
        void UpdateUser(User user);
        void Save();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}