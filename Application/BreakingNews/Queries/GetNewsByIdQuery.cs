using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Helpers;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.BreakingNews.Queries
{
    public class GetNewsByIdQuery : IRequest<BreakingNewsFullInfoVm>
    {
        public string Id { get; set; }

        public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, BreakingNewsFullInfoVm>
        {
            private readonly IRepository<News, string> repository;

            public GetNewsByIdQueryHandler(IRepository<News, string> repository)
            {
                this.repository = repository;
            }

            public async Task<BreakingNewsFullInfoVm> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
            {
                var item = await repository.GetByIdAsync(request.Id);

                if (item == null)
                {
                    string entityName = "News";
                    throw new NotFoundException(entityName, request.Id);
                }

                var dto = item.Mapping<News, BreakingNewsFullInfoVm>();
                return dto;
            }
        }
    }
}