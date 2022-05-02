using System.Threading.Tasks;
using BreakingNewsCore.Common.Models;
using BreakingNewsCore.Entities.UserEntity;

namespace BreakingNewsCore.Interfaces.Repositories
{
    public interface IUserRepository<T1, T2> where T1 : class
    {

        Task<T1> FindUserAsync(string userId);

        //Task<bool> IsInRoleAsync(string userId, string role);

        //Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(T1 user, T2 password);
        Task<(Result Result, string UserId)> UpdateUserAsync(T1 user);
        Task<Result> AddToRoleAsync(User user, string roleName);


        //Task<Result> DeleteUserAsync(string userId);
    }
}