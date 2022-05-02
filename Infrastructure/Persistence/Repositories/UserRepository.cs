using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BreakingNewsCore.Common.Models;
using BreakingNewsCore.Entities.UserEntity;
using BreakingNewsCore.Helpers;
using BreakingNewsCore.Interfaces.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository<User, string>
    {
        private readonly UserManager<User> _userManager;
        // private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result> AddToRoleAsync(User user, string roleName)
        {
           var result = await _userManager.AddToRoleAsync(user, roleName);
           return result.ToApplicationResult();
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<User> FindUserAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<(Result Result, string UserId)> UpdateUserAsync(User user)
        {
            var result = await _userManager.UpdateAsync(user);

            return (result.ToApplicationResult(), user.Id);
        }
    }
}