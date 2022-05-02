using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Common.Exceptions;
using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Interfaces.Repositories;

namespace BreakingNewsCore.BreakingNews.Commands
{
    public class DeleteNewsCommand : IRequest
    {
        public string Id { get; set; }

        public sealed class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand>
        {
            private readonly IRepository<News, string> _repository;

            public DeleteNewsCommandHandler(IRepository<News, string> repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
            {
                var deletedNews = await _repository.FindFirstOrDefaultAsync(request.Id);

                if (deletedNews == null)
                {
                    string entityName = "News";
                    throw new NotFoundException(entityName, request.Id);
                }

                _repository.Delete(deletedNews);
                await _repository.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}