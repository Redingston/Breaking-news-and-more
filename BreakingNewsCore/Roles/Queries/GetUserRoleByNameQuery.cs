using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Helpers;
using BreakingNewsCore.DTO.RolesDTO;
using BreakingNewsCore.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BreakingNewsCore.Roles.Queries
{
    public class GetUserRoleByNameQuery: IRequest<RoleDTO>
    {
        public string Name { get; set; }
        public class GetNewsByIdQueryHandler : IRequestHandler<GetUserRoleByNameQuery, RoleDTO>
        {
            private readonly IUserRoleRepository<IdentityRole, string> _repository;

            public GetNewsByIdQueryHandler(IUserRoleRepository<IdentityRole, string> repository)
            {
                _repository = repository;
            }

            public async Task<RoleDTO> Handle(GetUserRoleByNameQuery request, CancellationToken cancellationToken)
            {
                var result = await _repository.FindUserRoleByNameAsync(request.Name);

                return result.Mapping<IdentityRole, RoleDTO>();
            }
        }
    }
}