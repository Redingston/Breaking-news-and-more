using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BreakingNews.Commands
{
    public class CreateNewsCommand : IRequest<string>
    {
        public string Topic { get; set; }
        public string Text { get; set; }

        public sealed class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, string>
        {
            private readonly IRepository<News, string> _repository;

            public CreateNewsCommandHandler(IRepository<News, string> repository)
            {
                _repository = repository;
            }

            public async Task<string> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
            {
                var news = new Domain.Entities.News()
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = request.Text,
                    Topic = request.Topic,
                    TimeCreated = DateTime.Now.ToString("dddd, MMMM dd, yyyy, HH:mm:ss")
                };

                await _repository.Insert(news);

                await _repository.SaveChangesAsync(cancellationToken);

                return news.Id;
            }
        }
    }
}