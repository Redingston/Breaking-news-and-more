using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Application.Common.Models;
using Application.Helpers;

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