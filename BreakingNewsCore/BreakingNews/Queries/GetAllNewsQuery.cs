using BreakingNewsCore.Helpers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.DTO.NewsDTO;
using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Interfaces.Repositories;

namespace BreakingNewsCore.BreakingNews.Queries
{
    public class GetAllNewsQuery : IRequest<List<BreakingNewsDTO>>
    {

        public sealed class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, List<BreakingNewsDTO>>
        {
            private readonly IRepository<News, string> _repository;

            public GetAllNewsQueryHandler(IRepository<News, string> repository)
            {
                _repository = repository;
            }

            public async Task<List<BreakingNewsDTO>> Handle(GetAllNewsQuery request,
                                                           CancellationToken cancellationToken)
            {
                var news = await _repository.GetAllAsync(cancellationToken);
                var list = new List<BreakingNewsDTO>();

                foreach (var t in news)
                {
                    list.Add(t.Mapping<News, BreakingNewsDTO>());
                }

                return list;
            }
        }
    }
}