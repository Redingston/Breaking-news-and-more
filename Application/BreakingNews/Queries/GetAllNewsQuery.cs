using Application.Helpers;
using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO.NewsDTO;

namespace Application.BreakingNews.Queries
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