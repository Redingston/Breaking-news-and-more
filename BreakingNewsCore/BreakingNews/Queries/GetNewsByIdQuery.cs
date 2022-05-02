using BreakingNewsCore.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Common.Exceptions;
using BreakingNewsCore.DTO.NewsDTO;
using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Interfaces.Repositories;

namespace BreakingNewsCore.BreakingNews.Queries
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