using Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<(Result result, string userId)>
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, (Result result, string userId)>
        {
            private readonly IUserRepository<User, string> _userManager;

            public UpdateUserCommandHandler(IUserRepository<User, string> userManager)
            {
                _userManager = userManager;
            }
            public async Task<(Result result, string userId)> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindUserAsync(request.Id);

                if (user == null)
                {
                    string entityName = "User";
                    throw new NotFoundException(entityName, request.Id);
                }

                user.PhoneNumber = request.PhoneNumber;

                var result = await _userManager.UpdateUserAsync(user);

                return result;
            }
        }
    }
}