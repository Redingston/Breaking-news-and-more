using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.BreakingNews.Commands
{
    public class CreateNewsCommand : IRequest<string>
    {
        public string Topic { get; set; }
        public string Text { get; set; }
    }

    public sealed class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, string>
    {
        private readonly IApplicationDbContext context;

        public CreateNewsCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
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

            await context.BreakingNews.AddAsync(news);

            await context.SaveChangesAsync(cancellationToken);

            return news.Id;
        }
    }
}