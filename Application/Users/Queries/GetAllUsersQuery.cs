//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Application.Interfaces;
//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using Domain.Entities;
//using MediatR;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

//namespace Application.Users.Queries
//{
//    public class GetAllUsersQuery : IRequest<List<UserVm>>
//    {

//    }
//    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserVm>>
//    {
//        private readonly IUserRepository _context;

//        public GetAllUsersQueryHandler(IUserRepository context, IMapper mapper, IdentityDbContext<User> c)
//        {
//            _context = context;
//        }

//        public async Task<List<UserVm>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
//        {

//            // IEnumerable<User> users = _context.GetUsers();
//            var users = _context.GetUsers()
//                                .Select(p => new UserVm() { Email = p.Email, Id = p.Id, Name = p.UserName })
//                                .ToList();

//            return users;
//        }
//    }
//}