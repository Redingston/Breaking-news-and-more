using System.Threading;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Users
{
    public sealed class CreateUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
        {
            private readonly IUserRepository _repository;

            public CreateUserCommandHandler(IUserRepository repository)
            {
                _repository = repository;
            }

            public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User()
                {
                    UserName = request.Email,
                    Email = request.Email,
                    PasswordHash = request.Password
                };
                 _repository.CreateUser(user);
                await _repository.SaveChangesAsync(cancellationToken);
                return  user.Id;
            }
        }
    }
}