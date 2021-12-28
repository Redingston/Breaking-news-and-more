using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.BreakingNews.Commands
{
    public class UpdateNewsCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
    }

    public sealed class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, string>
    {
        private readonly IApplicationDbContext context;

        public UpdateNewsCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var updatedNews = await context.BreakingNews
                                           .FirstOrDefaultAsync(x => 
                                                                    x.Id == request.Id, cancellationToken);

            if (request.Topic != updatedNews.Topic )
            {
                updatedNews.Topic = request.Topic;
                updatedNews.LastTimeUpdated = DateTime.Now.ToString("dddd, MMMM dd, yyyy, HH:mm:ss");
            }

            if (request.Text != updatedNews.Text)
            {
                updatedNews.Text = request.Text;
                updatedNews.LastTimeUpdated = DateTime.Now.ToString("dddd, MMMM dd, yyyy, HH:mm:ss");
            }

            context.BreakingNews.Update(updatedNews);
            await context.SaveChangesAsync(cancellationToken);

            return updatedNews.Id;
        }
    }
}