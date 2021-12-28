using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BreakingNews.Commands
{
    public class DeleteNewsCommand : IRequest<string>
    {
        public string Id { get; set; }
    }

    public sealed class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, string>
    {
        private readonly IApplicationDbContext context;

        public DeleteNewsCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var deletedNews = await context.BreakingNews.FindAsync(request.Id);

            if (deletedNews == null)
            {
                return "News not found";
            }

            context.BreakingNews.Remove(deletedNews);
            await context.SaveChangesAsync(cancellationToken);

            return "News was successfully deleted";
        }
    }
}