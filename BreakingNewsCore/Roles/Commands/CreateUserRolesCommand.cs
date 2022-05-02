using BreakingNewsCore.Users.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Common.Exceptions;
using BreakingNewsCore.Common.Models;
using BreakingNewsCore.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BreakingNewsCore.Roles.Commands
{
    public class CreateUserRolesCommand : IRequest<(Result result, string roleId)>
    {
        public string Name { get; set; }

        public sealed class CreateUserRolesCommandHandler : IRequestHandler<CreateUserRolesCommand,
                                                            (Result result, string roleId)>
        {
            private readonly IUserRoleRepository<IdentityRole, string> _userManager;

            public CreateUserRolesCommandHandler(IUserRoleRepository<IdentityRole, string> userManager)
            {
                _userManager = userManager;
            }

            public async Task<(Result result, string roleId)> Handle(CreateUserRolesCommand request, CancellationToken cancellationToken)
            {
                var findRole = await _userManager.FindUserRoleByNameAsync(request.Name);

                if (findRole != null)
                {
                    throw new AlreadyExistsException(new Result(false, errors: new string[] {request.Name}));
                }
                
                var role = new IdentityRole(request.Name);

                var result = await _userManager.CreateUserRoleAsync(role);

                return result;
            }
        }
    }
}