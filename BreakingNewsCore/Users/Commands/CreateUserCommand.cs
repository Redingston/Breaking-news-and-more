using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Common.Exceptions;
using BreakingNewsCore.Common.Models;
using BreakingNewsCore.Entities.UserEntity;
using BreakingNewsCore.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BreakingNewsCore.Users.Commands
{
    public sealed class CreateUserCommand : IRequest<(Result, string)>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }

        public sealed class
            CreateUserCommandHandler : IRequestHandler<CreateUserCommand, (Result, string)>
        {
            private readonly IUserRepository<User, string> _userManager;
            private readonly IUserRoleRepository<IdentityRole, string> _roleRepository;

            public CreateUserCommandHandler(IUserRepository<User, string> userManager,
                IUserRoleRepository<IdentityRole, string> roleRepository)
            {
                _userManager = userManager;
                _roleRepository = roleRepository;
            }

            public async Task<(Result, string)> Handle(CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var user = new User()
                {
                    UserName = request.Email,
                    Email = request.Email,
                };
                var result = await _userManager.CreateUserAsync(user, request.Password);

                if (!result.Result.Succeeded)
                {
                    StringBuilder errorMessage = new();
                    foreach (var error in result.Result.Errors)
                    {
                        errorMessage.Append(error + " ");
                    }
                    throw new HttpException(System.Net.HttpStatusCode.BadRequest, errorMessage.ToString());
                }
                if (request.RoleName != null)
                {
                    var role = await _roleRepository.FindUserRoleByNameAsync(request.RoleName);
                    if (role == null)
                    {
                        await _roleRepository.CreateUserRoleAsync(new IdentityRole(request.RoleName));
                    }
                }
                
                await _userManager.AddToRoleAsync(user, request.RoleName);

                return result;
            }
        }
    }
}