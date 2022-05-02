using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Common.Exceptions;
using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Interfaces.Repositories;

namespace BreakingNewsCore.BreakingNews.Commands
{
    public class UpdateNewsCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }

        public sealed class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, string>
        {
            private readonly IRepository<News, string> _repository;

            public UpdateNewsCommandHandler(IRepository<News, string> repository)
            {
                _repository = repository;
            }

            public async Task<string> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
            {
                var updatedNews = await _repository.FindFirstOrDefaultAsync(request.Id);

                if (updatedNews == null)
                {
                    string entityName = "News";
                    throw new NotFoundException(entityName, request.Id);
                }

                if (request.Topic != updatedNews.Topic)
                {
                    updatedNews.Topic = request.Topic;
                    updatedNews.LastTimeUpdated = DateTime.Now.ToString("dddd, MMMM dd, yyyy, HH:mm:ss");
                }

                if (request.Text != updatedNews.Text)
                {
                    updatedNews.Text = request.Text;
                    updatedNews.LastTimeUpdated = DateTime.Now.ToString("dddd, MMMM dd, yyyy, HH:mm:ss");
                }

                _repository.Update(updatedNews);
                await _repository.SaveChangesAsync(cancellationToken);

                return updatedNews.Id;
            }
        }
    }
}