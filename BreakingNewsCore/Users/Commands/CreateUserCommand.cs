using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Roles.Queries;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Commands
{
    public sealed class CreateUserCommand : IRequest<(Result result, string userId)>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public sealed class
            CreateUserCommandHandler : IRequestHandler<CreateUserCommand, (Result result, string userId)>
        {
            private readonly IUserRepository<User, string> _userManager;
            private readonly IUserRoleRepository<IdentityRole, string> _roleRepository;

            public CreateUserCommandHandler(IUserRepository<User, string> userManager,
                IUserRoleRepository<IdentityRole, string> roleRepository)
            {
                _userManager = userManager;
                _roleRepository = roleRepository;
            }

            public async Task<(Result result, string userId)> Handle(CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var user = new User()
                {
                    UserName = request.Email,
                    Email = request.Email,
                    PasswordHash = request.Password
                };
                var result = await _userManager.CreateUserAsync(user, request.Password);

                var roleName = "authorizedUser";
                var role = await _roleRepository.FindUserRoleByNameAsync(roleName);

                if (role == null)
                {
                    await _roleRepository.CreateUserRoleAsync(new IdentityRole(roleName));
                }

                await _userManager.AddToRoleAsync(user, roleName);

                return result;
            }
        }
    }
}