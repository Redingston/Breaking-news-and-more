using BreakingNewsCore.Common.Models;
using BreakingNewsCore.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using BreakingNewsCore.Helpers;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRoleRepository : IUserRoleRepository<IdentityRole, string>
    {
        private readonly RoleManager<IdentityRole> _manager;

        public UserRoleRepository(RoleManager<IdentityRole> manager)
        {
            _manager = manager;
        }

        public async Task<(Result Result, string RoleId)> CreateUserRoleAsync(IdentityRole role)
        {
            var result = await _manager.CreateAsync(role);

            return (result.ToApplicationResult(), role.Id);
        }

        public async Task<IdentityRole> FindUserRoleByNameAsync(string roleName)
        {
            return await _manager.FindByNameAsync(roleName);
        }

        public async Task<(Result Result, string RoleId)> UpdateUserRoleAsync(IdentityRole role)
        {

            var result = await _manager.UpdateAsync(role);

            return (result.ToApplicationResult(), role.Id);
        }
    }
}