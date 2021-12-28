//using System.Threading;
//using Microsoft.AspNetCore.Identity;
//using System.Threading.Tasks;
//using System.Web.Mvc;
//using Application.Interfaces;
//using Domain.Entities;
//using MediatR;

//namespace Application.Users.Commands
//{
//    public sealed class CreateUserCommand : IRequest<string>
//    {
//        public string Email { get; set; }
//        public string Password { get; set; }

//        public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
//        {
//            private readonly IApplicationDbContext context;

//            public CreateUserCommandHandler(IApplicationDbContext context)
//            {
//                this.context = context;
//            }

//            public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
//            {
//                var user = new User()
//                {
//                    UserName = request.Email,
//                    Email = request.Email,
//                    PasswordHash = request.Password
//                };

//                await context.SaveChangesAsync(cancellationToken);
//                return user.Id;
//            }
//        }
//    }
//}