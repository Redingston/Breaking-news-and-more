using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Users
{
    public class GetAllUsersQuery : IRequest<List<UserVm>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserVm>>
        {
            private readonly IUserRepository _context;
            private readonly IMapper _mapper;
            private readonly IdentityDbContext<User> _c;

            public GetAllUsersQueryHandler(IUserRepository context, IMapper mapper, IdentityDbContext<User> c)
            {
                _context = context;
                _mapper = mapper;
                _c = c;
            }

            public async Task<List<UserVm>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
              // IEnumerable<User> users = _context.GetUsers();
              var users = await _c.Users
                                  .ProjectTo<UserVm>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
                       
               return users ;
            }
        }
    }
}