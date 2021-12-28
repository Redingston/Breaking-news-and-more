using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.BreakingNews.Queries
{
    public class GetNewsById : IRequest<BreakingNewsVm>
    {
        public string Id { get; set; }
    }

    public sealed class CreateNewsCommandHandler : IRequestHandler<GetNewsById, BreakingNewsVm>
    {
        private readonly IApplicationDbContext context;

        public CreateNewsCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<BreakingNewsVm> Handle(GetNewsById request, CancellationToken cancellationToken)
        {
            var item = await context.BreakingNews
                                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var dto = item.Mapping<News, BreakingNewsVm>();
            return dto;
        }
    }
}