using System.Threading.Tasks;
using Application.Common.Models;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository<T1, T2> where T1 : class
    {

        Task<T1> FindUserAsync(string userId);

        //Task<bool> IsInRoleAsync(string userId, string role);

        //Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(T1 user, T2 password);
        Task<(Result Result, string UserId)> UpdateUserAsync(T1 user);
        Task AddToRoleAsync(User user, string roleName);


        //Task<Result> DeleteUserAsync(string userId);
    }
}