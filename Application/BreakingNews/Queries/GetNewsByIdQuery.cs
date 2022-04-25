using Application.DTO.NewsDTO;
using Application.Common.Exceptions;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BreakingNews.Queries
{
    public class GetNewsByIdQuery : IRequest<BreakingNewsFullInfoDTO>
    {
        public string Id { get; set; }

        public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, BreakingNewsFullInfoDTO>
        {
            private readonly IRepository<News, string> repository;

            public GetNewsByIdQueryHandler(IRepository<News, string> repository)
            {
                this.repository = repository;
            }

            public async Task<BreakingNewsFullInfoDTO> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
            {
                var item = await repository.GetByIdAsync(request.Id);

                if (item == null)
                {
                    string entityName = "News";
                    throw new NotFoundException(entityName, request.Id);
                }

                var dto = item.Mapping<News, BreakingNewsFullInfoDTO>();
                return dto;
            }
        }
    }
}