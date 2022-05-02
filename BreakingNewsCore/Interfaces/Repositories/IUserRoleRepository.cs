using System.Threading.Tasks;
using BreakingNewsCore.Common.Models;

namespace BreakingNewsCore.Interfaces.Repositories
{
    public interface IUserRoleRepository<T1, T2> where T1 : class
    {
        Task<T1> FindUserRoleByNameAsync(string roleName);

        //Task<bool> IsInRoleAsync(string userId, string role);

        //Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string RoleId)> CreateUserRoleAsync(T1 role);
        Task<(Result Result, string RoleId)> UpdateUserRoleAsync(T1 role);


        //Task<Result> DeleteUserAsync(string userId);
    }
}